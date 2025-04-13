using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterFile;
using FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterInformation;
using FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById;
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
        public GetFilmPosterByIdService GetFilmPosterByIdService { get; }
        public UpdateFilmPosterInformationService UpdateFilmPosterInformationService { get; }
        public UpdateFilmPosterFileService UpdateFilmPosterFileService { get; }
    }
}
