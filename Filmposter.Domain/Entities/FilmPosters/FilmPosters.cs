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
        public string UniqueCode { get; set; } // this unique code is used as a standard url like:filmposter.ir/Ujh56a
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
        public byte ShortFeature { get; set; } // FilmposterShortFeatureConstants.cs
        public byte Style { get; set; }  // FilmposterStyleConstants.cs
        public byte Validation { get; set; } // FilmposterValidationConstants.cs
        public bool Worth { get; set; } // true: this poster is worth in our opionin [admin section]
    }
}
