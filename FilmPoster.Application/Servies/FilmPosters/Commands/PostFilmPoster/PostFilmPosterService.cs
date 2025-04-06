using AutoMapper;
using Filmposter.Domain.Common;
using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Servies.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster
{
    public class PostFilmPosterService : IPostFilmPosterService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PostFilmPosterService(IDataBaseContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<ResultDto> Execute(RequestPostFilmPosterServiceDto req)
        {
            // Validate input
            if (req == null
                || string.IsNullOrEmpty(req.TitleFa)
                || string.IsNullOrEmpty(req.Director)
                || string.IsNullOrEmpty(req.Producer)
                || string.IsNullOrEmpty(req.Summary))
            {
                return new ResultDto { IsSuccess = false, Message = "Invalid input data" };
            }

            try
            {
                string baseSlug = GenerateSlug(req.TitleFa);
                string uniqueSlug = EnsureUniqueSlug(baseSlug);
                string uniqueCode = EnsureUniqueCode(GenerateRandomString());

                var strategy = _context.Database.CreateExecutionStrategy();
                ResultDto result = null;

                await strategy.ExecuteAsync(async () =>
                {
                    await using var transaction = await _context.Database.BeginTransactionAsync();

                    try
                    {
                        var filmPosters = _mapper.Map<Filmposter.Domain.Entities.FilmPosters.FilmPosters>(req);
                        filmPosters.Slug = uniqueSlug;
                        filmPosters.UniqueCode = uniqueCode;
                        filmPosters.UserId = Guid.Parse("0f8fc878-da77-4bb7-bc2c-665c299efe25");
                        // Upload Headshot
                        var file = CreateFilename(req.File, 0, req.maxSize);
                        if (!file.Success)
                        {
                            await transaction.RollbackAsync();
                            result = new ResultDto { IsSuccess = false, Message = file.Message };
                            return;
                        }
                        filmPosters.File = file.Filename;

                        // Add to context and save
                        _context.FilmPosters.Add(filmPosters);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        result = new ResultDto { IsSuccess = true };
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        result = new ResultDto { IsSuccess = false, Message = $"Transaction failed: {ex.Message}" };
                    }
                    finally
                    {
                        if (transaction != null)
                        {
                            await transaction.DisposeAsync();
                        }
                    }
                });
                return result ?? new ResultDto { IsSuccess = false, Message = "Unexpected failure in transaction" };
            }
            catch (Exception ex)
            {
                return new ResultDto { IsSuccess = false, Message = $"Pre-transaction error: {ex.Message}" };
            }

        }
        public static string GenerateSlug(string title)
        {
            // Convert to lower case
            string slug = title.ToLower();

            // Remove invalid characters but allow Persian characters
            slug = Regex.Replace(slug, @"[^a-z0-9\u0600-\u06FF\s-]", "");

            // Replace multiple spaces with a single space
            slug = Regex.Replace(slug, @"\s+", " ").Trim();

            // Replace spaces with hyphens
            slug = slug.Replace(" ", "-");

            // Truncate to 60 characters
            if (slug.Length > 60)
            {
                slug = slug.Substring(0, 60).TrimEnd('-');
            }

            return slug;
        }
        public static string GenerateRandomString()
        {
            // Generate a random length between 3 and 10
            Random random = new Random();
            int length = random.Next(3, 11); // Inclusive range: 3 to 10

            // Generate a random string of the specified length
            const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string randomString = new string(Enumerable
                .Range(0, length)
                .Select(_ => characters[random.Next(characters.Length)])
                .ToArray());

            return randomString;
        }
        public string EnsureUniqueSlug(string baseSlug)
        {
            string slug = baseSlug;
            int counter = 1;

            // Check if slug already exists in the database
            while (_context.FilmPosters.Any(a => a.Slug == slug))  // While the slug already exists, keep adding a counter
            {
                slug = $"{baseSlug}-{counter}";
                counter++;
            }

            return slug;
        }
        public string EnsureUniqueCode(string baseUniqueCode)
        {
            string uniqueCode = baseUniqueCode;
            int counter = 1;
            // Check if slug already exists in the database
            var check = _context.FilmPosters.Any(a => a.UniqueCode == uniqueCode);
            while (check)
            {
                uniqueCode = $"{baseUniqueCode}-{counter}";
                counter++;
            }

            return uniqueCode;
        }
        private ResultUploadDto CreateFilename(IFormFile file, long userId, string maxSize)
        {
            UploadFileService uploadPhotoService = new UploadFileService(_configuration);
            var filename = uploadPhotoService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "admin-filmposter",
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
    }
}
