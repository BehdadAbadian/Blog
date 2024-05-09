using BM.Infrastructure.Query.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.Query.Article
{
    public class ArticleQueryView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ArticleCategory { get; set; }
        public string CreationDate { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int CommentCount { get; set; }
        public List<CommentQueryViewModel> Comments { get; set; }

    }
}
