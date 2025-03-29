using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.NationFilmPosters.FacadePattern
{
    public class NationFilmPostersFacadePattern: INationFilmPostersFacade
    {
        private readonly IDataBaseContext _context;
        public NationFilmPostersFacadePattern(IDataBaseContext context)
        {
            _context = context; 
        }
        // Get NationFilmPostersService
        public GetNationFilmPostersService _getNationFilmPostersService;
        public GetNationFilmPostersService GetNationFilmPostersService
        {
            get { return _getNationFilmPostersService = _getNationFilmPostersService ?? new GetNationFilmPostersService(_context); }
        }
    }
}
