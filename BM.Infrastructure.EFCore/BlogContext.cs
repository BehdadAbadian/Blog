using BM.Domain.ArticleAgg;
using BM.Domain.ArticleCategoryAgg;
using BM.Domain.CommentAgg;
using BM.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BM.Infrastructure.EFCore
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> articleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            //modelBuilder.ApplyConfiguration(new CommentMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
