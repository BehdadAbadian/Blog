using BM.Application.Contracts.Article;
using BM.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Areas.Admin.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;
        [BindProperty] public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }
        public EditModel(IArticleApplication articleApplication , IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleApplication.GetDetails(id);
            ArticleCategories = _categoryApplication.GetAll().Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }
        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(Article);
            return RedirectToPage("./Index");
        }
    }
}
