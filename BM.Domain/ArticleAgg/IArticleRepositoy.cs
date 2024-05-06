using BM.Application.Contracts.Article;

namespace BM.Domain.ArticleAgg
{
    public interface IArticleRepositoy
    {
        void Add(Article entity);
        Article Get(long id);
        bool Exits(string title);
        List<ArticleViewModel> GetList();
        EditArticle GetDetails(long id);
        void Save();
    }
}
