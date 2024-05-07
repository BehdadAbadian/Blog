using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.Query.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> Articles();
        ArticleQueryView ArticlesById(long id);
    }
}
