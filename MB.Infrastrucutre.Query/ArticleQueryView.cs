using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastrucutre.Query
{
    public class ArticleQueryView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Content { get; set; }
        public string ArticleCategory { get; set; }
        public string CreationDate { get; set; }
        public int CommentCount { get; set; }
        public List<CommentQueryView> Comments { get; set; }

    }
}
