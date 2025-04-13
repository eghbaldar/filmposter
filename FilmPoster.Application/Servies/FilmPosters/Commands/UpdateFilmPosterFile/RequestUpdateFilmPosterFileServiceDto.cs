using Microsoft.AspNetCore.Http;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterFile
{
    public class RequestUpdateFilmPosterFileServiceDto
    {
        public Guid PosterId { get; set; }
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }
        public string maxSize { get; set; }
    }
}
