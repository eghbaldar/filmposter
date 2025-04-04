using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.FilmPosters
{
    public class FilmPosters : BaseEntityGuid
    {
        public Guid UserId { get; set; }
        public virtual Filmposter.Domain.Entities.Users.Users User { get; set; }
        public bool FilmPoster { get; set; } // true: it means we designed the poster
        public bool Foreign { get; set; } // true: foreign false: iranian
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string Slug { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Summary { get; set; }
        public DateOnly ProductionDate { get; set; }
        public string File { get; set; }
        public bool ShortFeature { get; set; } // true: feature false:short
        public byte Style { get; set; }  // 0: fiction 1: doc 2: aniamtion 3: experimental 4:series 5:script cover
        public byte Validation { get; set; } // 0: under consideration 1: valid 2: invalid
        public bool Worth { get; set; } // true: this poster is worth in our opionin [admin section]
    }
}
