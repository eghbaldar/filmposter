using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.UploadFile
{
    public class ResultUploadDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Filename { get; set; }
    }
}
