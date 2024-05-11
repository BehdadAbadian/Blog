using BM.Application.Contracts.Comment;
using BM.Domain.CommentAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.EFCore.Repository
{
    public class CommentRepository : BaseRepository<long,Comment>, ICommentRepository 
    {
        private readonly BlogContext blogContext;

        public CommentRepository(BlogContext blogContext):base(blogContext) 
        {
            this.blogContext = blogContext;
        }

      
        public List<CommentViewModel> GetList()
        {
            return blogContext.Comments.Include(X=>X.Article).Select(x=> new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                CreationDate =x.CreationDate.ToString(),
                Message = x.Message,
                Article = x.Article.Title,
            }).OrderByDescending(x=>x.Id).ToList(); 
        }

       
    }
}
