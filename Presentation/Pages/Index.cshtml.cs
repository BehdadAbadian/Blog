using BM.Infrastructure.Query.Article;
using BM.Infrastructure.Query.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleQuery articleQuery;
        
        
        public List<ArticleQueryView> Articles;
        

        public IndexModel(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
            
        }

        public void OnGet()
        {
            Articles = articleQuery.Articles();
            
        }
    }
}
