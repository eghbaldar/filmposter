using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterInformation;
using FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Infrastructure.MappingProfiles
{
    public static class RegisterMapster
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {            
            TypeAdapterConfig<Filmposter.Domain.Entities.FilmPosters.FilmPosters, RequestPostFilmPosterServiceDto>.NewConfig();
            TypeAdapterConfig<Filmposter.Domain.Entities.FilmPosters.FilmPosters, GetFilmPosterByIdServiceDto>.NewConfig();
            TypeAdapterConfig<RequestUpdateFilmPosterInformationServiceDto, Filmposter.Domain.Entities.FilmPosters.FilmPosters>.NewConfig();
            // Add any other mappings you need in this profile
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
