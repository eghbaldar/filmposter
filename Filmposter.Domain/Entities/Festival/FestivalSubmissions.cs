using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Festival
{
    public class FestivalSubmissions: BaseEntityGuid
    {
        public Guid FestivalId { get; set; }
        public Festivals Festival { get; set; }
        public Guid UserId { get; set; }
        public virtual Filmposter.Domain.Entities.Users.Users User { get; set; }
        public string Filename { get; set; }
        public int PublicScores { get; set; } // Poeple's score from 1 to 10
    }
}
