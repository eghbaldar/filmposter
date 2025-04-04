namespace FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters
{
    public class GetFilmPostersServiceDto
    {
        public Guid Id { get; set; }
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string Slug { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Summary { get; set; }
        public DateOnly ProductionDate { get; set; }
        public string File { get; set; }
        public bool Foreign { get; set; } // true: foreign false: iranian
        public bool Worth { get; set; } // true: this poster is worth in our opionin
        public bool ShortFeature { get; set; } // true: feature false:short
        public byte Style { get; set; }  // 0: fiction 1: doc 2: aniamtion 3: experimental 4:series 5:script cover
        public byte Validation { get; set; } // 0: under consideration 1: valid 2: invalid
        public int Score { get; set; } // the vistiors' option from 0 to 10 scores
        public DateTime InsertDateTime { get; set; }
    }
}
