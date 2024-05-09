using BM.Application.Contracts.Comment;
using BM.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.EFCore.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext blogContext;

        public CommentRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public void Add(Comment entity)
        {
            blogContext.Comments.Add(entity);
            Save();
        }

        public List<CommentViewModel> GetAll()
        {
            return blogContext.Comments.Include(X=>X.Article).Select(x=> new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                CreationDate =x.CreationTime.ToString(),
                Message = x.Message,
                Article = x.Article.Title,
            }).OrderByDescending(x=>x.Id).ToList(); 
        }

        public Comment GetBy(long id)
        {
            return blogContext.Comments.FirstOrDefault(x=>x.Id == id);
        }

        public void Save()
        {
            blogContext.SaveChanges();
        }
    }
}
