using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Interfaces.FacadePattern
{
    public interface INationFilmPostersFacade
    {
        public GetNationFilmPostersService GetNationFilmPostersService { get; }
    }
}
