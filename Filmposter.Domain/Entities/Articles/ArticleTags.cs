using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Articles
{
    public class ArticleTags: BaseEntityGuid
    {
        public Guid ArticleId { get; set; }
        public virtual Articles Article { get; set; }
        public string Title { get; set; }
    }
}
