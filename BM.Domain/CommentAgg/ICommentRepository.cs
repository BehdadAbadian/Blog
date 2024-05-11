using BM.Application.Contracts.Comment;
using Framework.Infrastructure;

namespace BM.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,Comment>
    {
        
        List<CommentViewModel> GetList();

    }
}
