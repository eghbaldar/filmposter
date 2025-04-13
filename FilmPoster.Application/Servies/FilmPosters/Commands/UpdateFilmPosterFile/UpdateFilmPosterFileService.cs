using Filmposter.Domain.Common;
using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Servies.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterFile
{
    public class UpdateFilmPosterFileService : IUpdateFilmPosterFileService
    {
        private readonly IDataBaseContext _context;
        private readonly IConfiguration _configuration;
        public UpdateFilmPosterFileService(IDataBaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResultDto> Execute(RequestUpdateFilmPosterFileServiceDto req)
        {
            if (req.File == null || req == null || req.PosterId == Guid.Empty || int.Parse(req.maxSize) == 0) return new ResultDto { IsSuccess = false };
            try
            {
                var strategy = _context.Database.CreateExecutionStrategy();
                ResultDto result = null;

                await strategy.ExecuteAsync(async () =>
                {
                    await using var transaction = await _context.Database.BeginTransactionAsync();
                    var file = new ResultUploadDto();
                    try
                    {
                        //TODO: change the following line
                        req.UserId = Guid.Parse("0f8fc878-da77-4bb7-bc2c-665c299efe25");

                        // TODO: exculde the admins
                        var filmposter = _context.FilmPosters
                            .Where(x => x.Id == req.PosterId && x.UserId == req.UserId)
                            .FirstOrDefault();  // Fetch the entity first

                        // Upload Headshot
                        file = CreateFilename(req.File, 0, req.maxSize);
                        if (!file.Success)
                        {
                            await transaction.RollbackAsync();
                            result = new ResultDto { IsSuccess = false, Message = file.Message };
                            return;
                        }
                        filmposter.File = file.Filename;

                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        result = new ResultDto { IsSuccess = true, Message = file.Filename };
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        await DeleteFile(file);
                        result = new ResultDto { IsSuccess = false, Message = $"Transaction failed: {ex.Message}" };
                    }
                });
                return result ?? new ResultDto { IsSuccess = false, Message = "Unexpected failure in transaction" };
            }
            catch (Exception ex)
            {
                return new ResultDto { IsSuccess = false, Message = $"Pre-transaction error: {ex.Message}" };
            }
        }
        private ResultUploadDto CreateFilename(IFormFile file, long userId, string maxSize)
        {
            UploadFileService uploadPhotoService = new UploadFileService(_configuration);
            var filename = uploadPhotoService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                Path = UploadFileStaticPath.Filmposter,
                Extension = new string[] { ".jpg", ".png", ".bmp", ".jpeg" }, // always must be in way of lowerCase()s
                FileSize = maxSize,
                File = file,
                UsersId = userId,
                Scales = new Dictionary<string, string>
                        {
                        {"original","1500" },
                        {"thumb","500" },
                        }
            });
            return filename;
        }
        public async Task DeleteFile(ResultUploadDto req)
        {
            UploadFileService uploadPhotoService = new UploadFileService(_configuration);
            await uploadPhotoService.Delete(new RequestDeleteFileServiceDto
            {
                fileName = req.Filename,
                path = UploadFileStaticPath.Filmposter,
            });
        }
    }
}
