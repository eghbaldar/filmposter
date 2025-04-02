using Microsoft.AspNetCore.Http;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster
{
    public class RequestPostFilmPosterServiceDto
    {
        public bool FilmPoster { get; set; } // true: it means we designed the poster
        public bool Foreign { get; set; } // true: foreign false: iranian
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Summary { get; set; }
        public DateOnly ProductionDate { get; set; }
        public IFormFile File { get; set; }
        public string maxSize { get; set; }
        public bool Worth { get; set; } // true: this poster is worth in our opionin
        public bool ShortFeature { get; set; } // true: feature false:short
        public int Score { get; set; } // the vistiors' option from 0 to 10 scores
    }
}
