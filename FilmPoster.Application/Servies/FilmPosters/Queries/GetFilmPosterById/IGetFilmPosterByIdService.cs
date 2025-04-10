using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById
{
    public interface IGetFilmPosterByIdService
    {
        ResultGetFilmPosterByIdServiceDto Execute(RequestGetFilmPosterByIdDto req);
    }
}
