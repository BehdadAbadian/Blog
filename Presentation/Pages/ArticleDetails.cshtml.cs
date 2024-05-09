using BM.Application.Contracts.Comment;
using BM.Infrastructure.Query.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        private readonly IArticleQuery articleQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleQueryView Article;


        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            this.articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = articleQuery.ArticlesById(id);
        }
        public RedirectToPageResult OnPost(CreateComment command) 
        {
            _commentApplication.Create(command);
            return RedirectToPage("./ArticleDetails", new {id = command.ArticleId});
        }
    }
}
