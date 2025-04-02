using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.SMS.multipleParameteres
{
    public interface ISmsMultiService
    {
        Task<ResultDto> Execute(RequestSmsMultiServiceDto req);
    }
}
