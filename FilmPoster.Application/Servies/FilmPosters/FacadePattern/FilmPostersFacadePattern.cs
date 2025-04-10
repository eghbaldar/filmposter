using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById;
using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.FilmPosters.FacadePattern
{
    public class FilmPostersFacadePattern: IFilmPostersFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IConfiguration _configuration;

        public FilmPostersFacadePattern(IDataBaseContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // Get NationFilmPostersService
        public GetFilmPostersService _getNationFilmPostersService;
        public GetFilmPostersService GetFilmPostersService
        {
            get { return _getNationFilmPostersService = _getNationFilmPostersService ?? new GetFilmPostersService(_context); }
        }
        // Post FilmPosterService
        public PostFilmPosterService _postFilmPosterService;
        public PostFilmPosterService PostFilmPosterService
        {
            get { return _postFilmPosterService = _postFilmPosterService ?? new PostFilmPosterService(_context, _configuration); }
        }
        //Get FilmPosterByIdService
        public GetFilmPosterByIdService _getFilmPosterByIdService;
        public GetFilmPosterByIdService GetFilmPosterByIdService
        {
            get { return _getFilmPosterByIdService = _getFilmPosterByIdService ?? new GetFilmPosterByIdService(_context); }
        }
    }
}
