using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Contact
{
    public class Newsletters : BaseEntityGuid
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
