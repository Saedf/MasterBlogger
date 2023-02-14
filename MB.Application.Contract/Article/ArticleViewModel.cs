namespace MB.Application.Contract.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; }
        public string CreationDate { get; set; }
        public bool IsDelete { get; set; }

    }
}
