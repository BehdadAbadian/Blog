using BM.Application.Contracts.ArticleCategory;
using BM.Domain.ArticleCategoryAgg;

namespace BM.Application
{
    public class ArticleCategoryApplication: IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;


        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void Create(CreateArticleCategory command)
        {
            if (_articleCategoryRepository.Exists(x=>x.Title==command.Title))
                return;
            var category = new ArticleCategory(command.Title);
            _articleCategoryRepository.Create(category);
        }

        public void Delete(long id)
        {
            var category = _articleCategoryRepository.Get(id);
            if (category != null)
                _articleCategoryRepository.Delete(category);
        }

        public void Edit(EditArticleCategory command)
        {
            var category = _articleCategoryRepository.Get(command.Id);
            category.Edit(command.Title);
            _articleCategoryRepository.Save();

        }

        public EditArticleCategory GetBy(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            return _articleCategoryRepository.GetList();
        }

        public void Remove(long id)
        {
            var category = _articleCategoryRepository.Get(id);
            category.Remove();
            _articleCategoryRepository.Save();
        }

        public void Restore(long id)
        {
            var category = _articleCategoryRepository.Get(id);
            category.Restore();
            _articleCategoryRepository.Save();
        }
    }
}

