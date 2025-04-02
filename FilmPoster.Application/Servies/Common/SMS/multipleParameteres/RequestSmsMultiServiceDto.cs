using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.SMS.multipleParameteres
{
    public class RequestSmsMultiServiceDto
    {
        public Guid UserId { get; set; }
        public string Pattern { get; set; }
        public List<Dictionary<string, string>> Arguments_Parameters { get; set; }
    }
}
