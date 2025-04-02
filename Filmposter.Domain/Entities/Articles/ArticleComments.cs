using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Articles
{
    public class ArticleComments: BaseEntityGuid
    {
        public Guid ArticleId { get; set; }
        public virtual Articles Article { get; set; }
        public bool Admin { get; set; } = false; // False=> Regular User True=> Admin
        public Guid? SubCommentId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public byte Active { get; set; } = 0; // 0=> under considration 1=> accepted 2=> rejected
    }
}
