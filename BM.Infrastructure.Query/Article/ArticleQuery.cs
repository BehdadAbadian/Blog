using BM.Domain.CommentAgg;
using BM.Infrastructure.EFCore;
using BM.Infrastructure.Query.Comment;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BM.Infrastructure.Query.Article
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public List<ArticleQueryView> Articles()
        {
            return blogContext.Articles
                .Include(x=> x.ArticleCategory)
                .Include(x=> x.Comments)
                .Where(x=>x.IsDeleted == false).Select(x=> new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title,
                CommentCount = x.Comments.Count(x => x.Status == Statuses.Confirmed)

            }).OrderByDescending(x=>x.Id).ToList();
        }

        public ArticleQueryView ArticlesById(long id)
        {
            return blogContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title,
                CommentCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(z => z.Status == Statuses.Confirmed))

            }).FirstOrDefault(x=>x.Id == id);
        }

        private static List<CommentQueryViewModel> MapComments(IEnumerable<BM.Domain.CommentAgg.Comment> comments)
        {
            return comments.Select(comment => new CommentQueryViewModel
            {
                Name = comment.Name,
                CreationDate = comment.CreationTime.ToString(CultureInfo.InvariantCulture),
                Message = comment.Message
            }).ToList();
        }
    }
}
