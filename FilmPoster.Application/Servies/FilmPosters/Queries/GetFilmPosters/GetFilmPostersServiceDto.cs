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
        public bool Worth { get; set; } // true: this poster is worth in our opionin
        public bool ShortFeature { get; set; } // true: feature false:short
        public int Score { get; set; } // the vistiors' option from 0 to 10 scores
        public DateTime InsertDateTime { get; set; }
    }
}
