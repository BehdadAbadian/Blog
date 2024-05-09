using BM.Application.Contracts.Comment;
using BM.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Create(CreateComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Add(comment);    
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Reject(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Reject();
            _commentRepository.Save();
        }

        public List<CommentViewModel> GetAll()
        {
            return _commentRepository.GetAll();
        }
    }
}
