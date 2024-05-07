using BM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.Query.Article
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public List<ArticleQueryView> Articles()
        {
            return blogContext.Articles.Include(x=> x.ArticleCategory).Where(x=>x.IsDeleted == false).Select(x=> new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title

            }).OrderByDescending(x=>x.Id).ToList();
        }

        public ArticleQueryView ArticlesById(long id)
        {
            return blogContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title

            }).FirstOrDefault(x=>x.Id == id);
        }
    }
}
