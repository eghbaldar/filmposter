using FilmPoster.Application.Interfaces.Contexts;

namespace FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters
{
    public class GetNationFilmPostersService : IGetNationFilmPostersService
    {
        private readonly IDataBaseContext _context;
        public GetNationFilmPostersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNationFilmPostersServiceDto Execute()
        {
            var posters = _context.NationFilmPosters
                .Select(x => new GetNationFilmPostersServiceDto
                {
                    Director = x.Director,
                    File = x.File,
                    Id = x.Id,
                    InsertDateTime = x.InsertDate,
                    Producer = x.Producer,
                    ProductionDate = x.ProductionDate,
                    Score = x.Score,
                    ShortFeature = x.ShortFeature,
                    Summary = x.Summary,
                    TitleEn = x.TitleEn,
                    TitleFa = x.TitleFa,
                    Worth = x.Worth,
                    Slug = x.Slug
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResultGetNationFilmPostersServiceDto
            {
                Result = posters,
            };
        }
    }
}
