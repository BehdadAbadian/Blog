using BM.Application.Contracts.Article;
using BM.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Areas.Admin.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;
        public List<SelectListItem> ArticleCategories;

        public CreateModel(IArticleCategoryApplication categoryApplication, IArticleApplication articleApplication)
        {
            _categoryApplication = categoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _categoryApplication.GetAll().Select(x => new SelectListItem(x.Title,x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost(CreateArticle command) 
        {
            _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
