using BM.Application.Contracts.ArticleCategory;
using BM.Domain.ArticleCategoryAgg;

namespace BM.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public void Add(ArticleCategory category)
        {
            _blogContext.articleCategories.Add(category);
            Save();
        }

        public void Delete(ArticleCategory category)
        {
            _blogContext.articleCategories.Remove(category);
            Save();
        }

        public bool Exists(string title)
        {
            return _blogContext.articleCategories.Any(c => c.Title == title);
        }

        public ArticleCategory Get(long id)
        {
            return _blogContext.articleCategories.FirstOrDefault(x=>x.Id == id);
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

        public void Save()
        {
            _blogContext.SaveChanges();
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            var query = _blogContext.articleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationTime = x.CreationTime.ToString()
            });
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
