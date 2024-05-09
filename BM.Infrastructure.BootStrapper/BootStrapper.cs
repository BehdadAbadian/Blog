using BM.Application;
using BM.Application.Contracts.Article;
using BM.Application.Contracts.ArticleCategory;
using BM.Application.Contracts.Comment;
using BM.Domain.ArticleAgg;
using BM.Domain.ArticleCategoryAgg;
using BM.Domain.CommentAgg;
using BM.Infrastructure.EFCore;
using BM.Infrastructure.EFCore.Repository;
using BM.Infrastructure.Query.Article;
using BM.Infrastructure.Query.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BM.Infrastructure.Configuration
{
    public class BootStrapper
    {
        public static void Config(IServiceCollection service, string connectionString)
        {
            service.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            service.AddTransient<IArticleRepositoy, ArticleRepository>();
            service.AddTransient<IArticleApplication, ArticleApplication>();

            service.AddTransient<ICommentApplication, CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();


            service.AddTransient<IArticleQuery, ArticleQuery>();
            
        }
    }
}
