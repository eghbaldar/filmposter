using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Users
{
    public class Users : BaseEntityGuid
    {
        public string Fullname { get; set; }
        public string? Email { get; set; }
        public bool ValidationEmail { get; set; }
        public string? Phone { get; set; }
        public bool ValidationPhone { get; set; }
        public string Role { get; set; } // UserRoleConstants.cs
        public double Wallet { get; set; }
        public ICollection<Filmposter.Domain.Entities.Articles.Articles> Articles { get; set; }
        public ICollection<UserLogs> UserLogs { get; set; }
        public ICollection<UserPayments> UserPayments { get; set; }
    }
}
