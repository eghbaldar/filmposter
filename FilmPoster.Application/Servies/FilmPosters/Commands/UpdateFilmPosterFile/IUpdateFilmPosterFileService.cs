using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterFile
{
    public interface IUpdateFilmPosterFileService
    {
        Task<ResultDto> Execute(RequestUpdateFilmPosterFileServiceDto req);
    }
}
