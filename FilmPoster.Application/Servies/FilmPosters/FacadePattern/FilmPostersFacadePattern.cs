using AutoMapper;
using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public FilmPostersFacadePattern(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            get { return _postFilmPosterService = _postFilmPosterService ?? new PostFilmPosterService(_context, _mapper); }
        }
    }
}
