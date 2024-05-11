using BM.Application.Contracts.ArticleCategory;
using BM.Domain.ArticleCategoryAgg;
using Framework.Infrastructure;

namespace BM.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : BaseRepository<long,ArticleCategory> , IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }
        public void Delete(ArticleCategory category)
        {
            _blogContext.articleCategories.Remove(category);
            Save();
        }

        public EditArticleCategory GetDetails(long id)
        {
            var query = _blogContext.articleCategories.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                Title = x.Title,
            }).FirstOrDefault(x=>x.Id ==id);
            return query;
        }

        public List<ArticleCategoryViewModel> GetList()
        {
            var query = _blogContext.articleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString()
            });
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
