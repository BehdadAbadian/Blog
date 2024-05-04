using BM.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Add(ArticleCategory category);
        void Delete(ArticleCategory category);
        bool Exists(string title);
        ArticleCategory Get(long id);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetAll();
        void Save();

    }
}
