using Filmposter.Domain.Common;
using FilmPoster.Application.Interfaces.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterInformation
{
    public class UpdateFilmPosterInformationService : IUpdateFilmPosterInformationService
    {
        private readonly IDataBaseContext _context;
        public UpdateFilmPosterInformationService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestUpdateFilmPosterInformationServiceDto req)
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

                var strategy = _context.Database.CreateExecutionStrategy();
                ResultDto result = null;

                await strategy.ExecuteAsync(async () =>
                {
                    await using var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        var filmposter = _context.FilmPosters
                        .Where(x =>
                        x.Id == req.PosterId
                        //TODO: change the following line
                        && x.UserId == Guid.Parse("0f8fc878-da77-4bb7-bc2c-665c299efe25"))
                        .FirstOrDefault();

                        if (filmposter != null)
                        {
                            //filmposter.Adapt(req);
                            req.Slug = uniqueSlug;
                            req.Adapt(filmposter);

                            // Add to context and save
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();

                            result = new ResultDto { IsSuccess = true };
                        }
                        else
                        {
                            result = new ResultDto { IsSuccess = false, Message = $"پوستری با این مشخصات وجود ندارد." };
                        }
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
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
    }
}
