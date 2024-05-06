using BM.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationTime { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
        }

        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreationTime = DateTime.Now;
            Articles = new List<Article>();
        }
        public void Edit(string title)
        {
            Title = title;
        }
        public void Remove() 
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }

}
