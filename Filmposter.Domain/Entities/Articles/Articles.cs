using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Articles
{
    public class Articles: BaseEntityGuid
    {
        public Guid UserId { get; set; }
        public virtual Users.Users User { get; set; }
        public Guid ArticleCategoryId { get; set; }
        public virtual ArticleCategories ArticleCategory { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string UniqueCode { get; set; } // استفاده از لینک مقاله بصورت لینک کوتاه - این رشته بصورت اتوماتیک تولید میشود
        public string Summary { get; set; }
        public string BodyText { get; set; }
        public string MainPhoto { get; set; }
        public string Author { get; set; }
        public string? Preference { get; set; }
        public bool Active { get; set; }
        public int Visit { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<ArticleTags> ArticleTags { get; set; }
        public ICollection<ArticleComments> ArticleComments { get; set; }
    }
}
