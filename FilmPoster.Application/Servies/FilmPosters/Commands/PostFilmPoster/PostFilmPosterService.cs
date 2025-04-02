using AutoMapper;
using Filmposter.Domain.Common;
using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Servies.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster
{
    public class PostFilmPosterService: IPostFilmPosterService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostFilmPosterService(IDataBaseContext context, IMapper mapper)
        {   
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResultDto> Execute(RequestPostFilmPosterServiceDto req)
        {
            if(req == null
                || string.IsNullOrEmpty(req.TitleFa)
                || string.IsNullOrEmpty(req.Director)
                || string.IsNullOrEmpty(req.Producer)
                || string.IsNullOrEmpty(req.Summary)) return new ResultDto { IsSuccess = false };

            string baseSlug = GenerateSlug(req.TitleFa);
            string uniqueSlug = EnsureUniqueSlug(baseSlug);
            string uniqueCode = EnsureUniqueCode(GenerateRandomString());

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Filmposter.Domain.Entities.FilmPosters.FilmPosters filmPosters = new Filmposter.Domain.Entities.FilmPosters.FilmPosters();
                    filmPosters = _mapper.Map<Filmposter.Domain.Entities.FilmPosters.FilmPosters>(req);
                    filmPosters.Slug = uniqueSlug;
                    //========================= Upload Headshot
                    var file = CreateFilename(req.File, 0, req.maxSize); ;
                    switch (file.Success)
                    {
                        case true:
                            filmPosters.File = file.Filename;
                            break;
                        case false:
                            return new ResultDto
                            {
                                IsSuccess = false,
                                Message = file.Message,
                            };
                    }
                    //========================= add tags

                    _context.FilmPosters.Add(filmPosters);
                    return new ResultDto { IsSuccess = true };
                }
                catch (Exception ex)
                {
                    // Step 4: Rollback the transaction if any error occurs
                    await transaction.RollbackAsync();
                    return new ResultDto { Message = ex.Message };
                    // Optionally log the exception here
                    //throw; // Re-throw the exception for higher-level handling
                }
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

            while (_context.Articles.Any(a => a.Slug == slug))
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

            while (_context.Articles.Any(a => a.UniqueCode == uniqueCode))
            {
                uniqueCode = $"{baseUniqueCode}-{counter}";
                counter++;
            }

            return uniqueCode;
        }
        private ResultUploadDto CreateFilename(IFormFile file, long userId, string maxSize)
        {
            UploadFileService uploadPhotoService = new UploadFileService();
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
