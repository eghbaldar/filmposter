using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Articles
{
    public class ArticleCategories: BaseEntityGuid
    {
        public long AutoIncrementId { get; set; } // because I can't use GUID to show in public
        public string Title { get; set; }
        public bool MainSub { get; set; } // false: Main true: Sub
        public Guid SubId { get; set; } // برای دسته بندی های زیر دسته قبلی
        public virtual ICollection<Articles> Articles { get; set; } // Navigation property for articles
    }
}
