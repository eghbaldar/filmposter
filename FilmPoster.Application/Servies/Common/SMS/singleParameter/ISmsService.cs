using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.SMS.singleParameter
{
    public interface ISmsService
    {
        Task<ResultDto> Execute(RequestSmsServiceDto req);
    }
}
