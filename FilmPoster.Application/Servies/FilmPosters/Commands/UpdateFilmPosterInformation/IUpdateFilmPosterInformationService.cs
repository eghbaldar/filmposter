using Filmposter.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterInformation
{
    public interface IUpdateFilmPosterInformationService
    {
        Task<ResultDto> Execute(RequestUpdateFilmPosterInformationServiceDto req);
    }
}
