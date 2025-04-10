using Filmposter.Domain.Common;
using FilmPoster.Application.Interfaces.Contexts;
using Mapster;

namespace FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById
{
    public class GetFilmPosterByIdService : IGetFilmPosterByIdService
    {
        private readonly IDataBaseContext _context;
        public GetFilmPosterByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetFilmPosterByIdServiceDto Execute(RequestGetFilmPosterByIdDto req)
        {
            var filmposter = _context.FilmPosters.Where(x => x.Id == req.PosterId).FirstOrDefault();  // Fetch the entity first

            if (filmposter != null)
            {
                // Map the entity to DTO
                var resultDto = filmposter.Adapt<GetFilmPosterByIdServiceDto>();                

                return new ResultGetFilmPosterByIdServiceDto
                {
                    Result = new ResultDto<GetFilmPosterByIdServiceDto>
                    {
                        IsSuccess = true,
                        Date = resultDto
                    }
                };
            }
            else
            {
                return new ResultGetFilmPosterByIdServiceDto
                {
                    Result = new ResultDto<GetFilmPosterByIdServiceDto>
                    {
                        IsSuccess = false,
                        Message = "Film poster not found.",
                        Date = null
                    }
                };
            }

        }

    }
}
