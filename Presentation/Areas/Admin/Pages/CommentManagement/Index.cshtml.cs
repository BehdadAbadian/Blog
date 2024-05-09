using BM.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Areas.Admin.Pages.CommentManagement
{
    public class IndexModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> Comments;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetAll();
        }
        public RedirectToPageResult OnGetConfirm(long id) 
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetReject(long id)
        {
            _commentApplication.Reject(id);
            return RedirectToPage("./Index");
        }
    }
}
