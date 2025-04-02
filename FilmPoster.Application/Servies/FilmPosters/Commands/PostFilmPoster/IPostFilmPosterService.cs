using Filmposter.Domain.Common;
using Filmposter.Domain.Entities.Articles;
using Filmposter.Domain.Entities.FilmPosters;
using Filmposter.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster
{
    public interface IPostFilmPosterService
    {
        Task<ResultDto> Execute(RequestPostFilmPosterServiceDto req);
    }
}
