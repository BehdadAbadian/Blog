using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        List<ArticleCategoryViewModel> GetAll();
        EditArticleCategory GetBy(long id);
        void Remove(long id);
        void Restore(long id);
        void Delete(long id);

    }
}
