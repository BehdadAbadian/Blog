using BM.Infrastructure.Query.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        private readonly IArticleQuery articleQuery;
        public ArticleQueryView Article;

        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            Article = articleQuery.ArticlesById(id);
        }
    }
}
