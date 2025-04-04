using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.FilmPosters
{
    public class FilmPosterScores : BaseEntityGuid
    {
        public Guid FilmPosterId { get; set; }
        public FilmPosters FilmPoster { get; set; }
        public Guid UserId { get; set; }
        public virtual Filmposter.Domain.Entities.Users.Users User { get; set; }
        public int Score { get; set; }
    }
}
