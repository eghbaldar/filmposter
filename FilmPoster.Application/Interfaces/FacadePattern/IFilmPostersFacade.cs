using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Interfaces.FacadePattern
{
    public interface IFilmPostersFacade
    {
        public GetFilmPostersService GetFilmPostersService { get; }
        public PostFilmPosterService PostFilmPosterService { get; }
    }
}
