using System.ComponentModel.DataAnnotations;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterInformation
{
    public class RequestUpdateFilmPosterInformationServiceDto
    {
        public Guid PosterId { get; set; }
        [Required(ErrorMessage = "عنوان فارسی پوستر الزامی است.")]
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string? Slug { get; set; }
        [Required(ErrorMessage = "نام کامل کارگردان اثر الزامی است.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "نام کامل تهیه کننده اثر الزامی است.")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "خلاصه داستان اثر الزامی است.")]
        [MaxLength(50, ErrorMessage = "خلاصه داستان به اندازه کافی گویا نیست.")]
        public string Summary { get; set; }
        public bool FilmPoster { get; set; } // true: it means we designed the poster
        public DateOnly ProductionDate { get; set; }
        public bool Foreign { get; set; } // true: foreign false: iranian
        public bool Worth { get; set; } // true: this poster is worth in our opionin
        public byte ShortFeature { get; set; } // true: feature false:short
        public byte Style { get; set; }  // 0: fiction 1: doc 2: aniamtion 3: experimental 4:series 5:script cover
        public byte Validation { get; set; } // 0: under consideration 1: valid 2: invalid
    }
}
