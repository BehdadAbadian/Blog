using BM.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Areas.Admin.Pages.ArticleManagement
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public List<ArticleViewModel> Articles;

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetAllArticles();
        }
        public RedirectToPageResult OnGetRemove(long id) 
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRestore(long id)
        {
            _articleApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
