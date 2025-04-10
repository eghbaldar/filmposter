using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
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
            // Map FilmPosters entity to RequestPostFilmPosterServiceDto and vice versa
            TypeAdapterConfig<Filmposter.Domain.Entities.FilmPosters.FilmPosters, RequestPostFilmPosterServiceDto>.NewConfig();

            // Map FilmPosters entity to GetFilmPosterByIdServiceDto and vice versa
            TypeAdapterConfig<Filmposter.Domain.Entities.FilmPosters.FilmPosters, GetFilmPosterByIdServiceDto>.NewConfig();

            // Add any other mappings you need in this profile
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
