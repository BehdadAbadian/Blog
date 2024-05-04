using BM.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditArticleCategory ArticleCategory { get; set; }

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.GetBy(id);
        }
        public RedirectToPageResult OnPost(EditArticleCategory ArticleCategory) 
        {
            _articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("./Index");
        }
    }
}
