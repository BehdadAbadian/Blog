using BM.Application.Contracts.Article;
using BM.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepositoy _articleRepositoy;

        public ArticleApplication(IArticleRepositoy articleRepositoy)
        {
            _articleRepositoy = articleRepositoy;
        }

        public void Create(CreateArticle command)
        {
            if (_articleRepositoy.Exists(x=>x.Title == command.Title))
                return; ;
            var Article = new Article(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepositoy.Create(Article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepositoy.Get(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepositoy.Save();
        }

        public List<ArticleViewModel> GetAllArticles()
        {
            return _articleRepositoy.GetList();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepositoy.GetDetails(id);
        }

        public void Remove(long id)
        {
            var article = _articleRepositoy.Get(id);
            article.Remove();
            _articleRepositoy.Save();
        }

        public void Restore(long id)
        {
            var article = _articleRepositoy.Get(id);
            article.Restore();
            _articleRepositoy.Save();
        }
    }
}
