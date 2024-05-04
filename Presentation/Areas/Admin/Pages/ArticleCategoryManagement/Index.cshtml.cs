using BM.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<ArticleCategoryViewModel> ArticleCategories;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.GetAll();
        }
        public RedirectToPageResult OnGetRemove(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRestore(long id)
        {
            _articleCategoryApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
