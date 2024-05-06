using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAllArticles();
        EditArticle GetDetails(long id);
        void Edit(EditArticle command);
        void Create(CreateArticle command);
        void Remove(long id);
        void Restore(long id);
    }
}
