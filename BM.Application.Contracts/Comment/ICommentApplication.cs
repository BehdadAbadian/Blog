using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void Create(CreateComment command);
        List<CommentViewModel> GetAll();
        
        void Confirm(long id);
        void Reject(long id);
    }
}
