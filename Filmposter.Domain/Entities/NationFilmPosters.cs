using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities
{
    public class NationFilmPosters: BaseEntityGuid
    {
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
    }
}
