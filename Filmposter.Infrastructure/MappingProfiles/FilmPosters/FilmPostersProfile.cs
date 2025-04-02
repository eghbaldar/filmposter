using AutoMapper;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Infrastructure.MappingProfiles.FilmPosters
{
    public class FilmPostersProfile:Profile
    {
        public FilmPostersProfile()
        {
            CreateMap<Filmposter.Domain.Entities.FilmPosters.FilmPosters, RequestPostFilmPosterServiceDto>().ReverseMap();
        }
    }
}
