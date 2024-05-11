using BM.Application.Contracts.ArticleCategory;
using Framework.Infrastructure;


namespace BM.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long,ArticleCategory>
    {
        
        void Delete(ArticleCategory category);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetList();
       
    }
}
