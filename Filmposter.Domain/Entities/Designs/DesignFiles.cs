using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Designs
{
    public class DesignFiles:BaseEntityGuid
    {
        public Guid DesignId { get; set; }
        public virtual Designs Design { get; set; }
        public string Filename { get; set; }
    }
}
