using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Festival
{
    public class Festivals:BaseEntityGuid
    {
        [MaxLength(4)]
        [MinLength(4)]
        public string Year { get; set; } // like: 2025,...
        public string? Slogan { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string? Description { get; set; }
    }
}
