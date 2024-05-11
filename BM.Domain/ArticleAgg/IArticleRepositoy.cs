using BM.Application.Contracts.Article;
using Framework.Infrastructure;

namespace BM.Domain.ArticleAgg
{
    public interface IArticleRepositoy : IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
        EditArticle GetDetails(long id);
    }
}
