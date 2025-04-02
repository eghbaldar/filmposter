using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters
{
    public interface IGetFilmPostersService
    {
        ResultGetFilmPostersServiceDto Execute();
    }
}
