using FilmPoster.Application.Interfaces.Contexts;

namespace FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters
{
    public class GetFilmPostersService : IGetFilmPostersService
    {
        private readonly IDataBaseContext _context;
        public GetFilmPostersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetFilmPostersServiceDto Execute()
        {
            var posters = _context.FilmPosters
                .Select(x => new GetFilmPostersServiceDto
                {
                    Director = x.Director,
                    File = x.File,
                    Id = x.Id,
                    InsertDateTime = x.InsertDate,
                    Producer = x.Producer,
                    ProductionDate = x.ProductionDate,
                    ShortFeature = x.ShortFeature,
                    Summary = x.Summary,
                    TitleEn = x.TitleEn,
                    TitleFa = x.TitleFa,
                    Worth = x.Worth,
                    Slug = x.Slug,
                    Foreign = x.Foreign,
                    Style = x.Style,
                    Validation = x.Validation
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResultGetFilmPostersServiceDto
            {
                Result = posters,
            };
        }
    }
}
