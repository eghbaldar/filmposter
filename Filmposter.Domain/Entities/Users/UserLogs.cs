using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Users
{
    public class UserLogs : BaseEntityGuid
    {
        public Guid UserId { get; set; }
        public virtual Users User { get; set; }
        public string? Page { get; set; }
        public string IP { get; set; }
    }
}
