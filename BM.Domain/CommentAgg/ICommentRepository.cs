using BM.Application.Contracts.Comment;

namespace BM.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Add(Comment entity);
        List<CommentViewModel> GetAll();
        Comment GetBy(long id);
        void Save();
    }
}
