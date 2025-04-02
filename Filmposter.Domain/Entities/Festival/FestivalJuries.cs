using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Festival
{
    public class FestivalJuries: BaseEntityGuid
    {
        public Guid FestivalId { get; set; }
        public Festivals Festival { get; set; }
        public string Fullname { get; set; }
        public string Resume { get; set; }
    }
}
