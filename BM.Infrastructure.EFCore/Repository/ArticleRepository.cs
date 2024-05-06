using BM.Application.Contracts.Article;
using BM.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : IArticleRepositoy
    {
        private readonly BlogContext blogContext;

        public ArticleRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public void Add(Article entity)
        {
            blogContext.Articles.Add(entity);  
            Save();
        }

        public bool Exits(string title)
        {
            return blogContext.Articles.Any(x => x.Title == title);
        }

        public Article Get(long id)
        {
            return blogContext.Articles.FirstOrDefault(x => x.Id == id);
        }

        public EditArticle GetDetails(long id)
        {
             return blogContext.Articles.Include(x => x.ArticleCategory)
                .Select(x => new EditArticle
                {
                    Id =x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Image = x.Image,
                    ArticleCategoryId =x.ArticleCategoryId,
                    Content = x.Content,
                }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> GetList()
        {
            return blogContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel 
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString()
            }).OrderByDescending(x=>x.Id).ToList();
        }

        public void Save()
        {
            blogContext.SaveChanges();
        }
    }
}
