using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster
{
    public class RequestPostFilmPosterServiceDto
    {
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
        public DateOnly ProductionDate { get; set; }

        /// <summary>
        /// /////////////////////////////////////
        /// read me about the following properties:
        /// https://blog.eghbaldar.ir/showthread.php?tid=250
        /// </summary>
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "فایل پوستر انتخاب نشده است.")]
        public string Filename { get; set; }
        // End of summary
        public bool FilmPoster { get; set; } // true: it means we designed the poster

        public string maxSize { get; set; }
        public bool Foreign { get; set; } // true: foreign false: iranian
        public bool Worth { get; set; } // true: this poster is worth in our opionin
        public byte ShortFeature { get; set; } // true: feature false:short
        public byte Style { get; set; }  // 0: fiction 1: doc 2: aniamtion 3: experimental 4:series 5:script cover
        public byte Validation { get; set; } // 0: under consideration 1: valid 2: invalid
    }
}
