using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Designs
{
    public class Designs:BaseEntityGuid
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DesingerFullname { get; set; }
    }
}
