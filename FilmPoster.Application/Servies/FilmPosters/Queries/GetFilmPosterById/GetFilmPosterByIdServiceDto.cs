using System.ComponentModel.DataAnnotations;

namespace FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById
{
    public class GetFilmPosterByIdServiceDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UniqueCode { get; set; } // this unique code is used as a standard url like:filmposter.ir/Ujh56a
        public bool FilmPoster { get; set; } // true: it means we designed the poster
        public bool Foreign { get; set; } // true: foreign false: iranian
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
        public string File { get; set; }
        public byte ShortFeature { get; set; } // FilmposterShortFeatureConstants.cs
        public byte Style { get; set; }  // FilmposterStyleConstants.cs
        public byte Validation { get; set; } // 0: under consideration 1: valid 2: invalid
        public bool Worth { get; set; } // true: this poster is worth in our opionin [admin section]
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
