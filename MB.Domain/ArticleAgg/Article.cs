using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShorDecription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PicturTitle { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
            
        }

        public Article(string title, string shorDecription, string picture, string pictureAlt, string picturTitle, string content, long articleCategoryId)
        {
            Title = title;
            ShorDecription = shorDecription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PicturTitle = picturTitle;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            CreationDate=DateTime.Now;
            IsDeleted = false;
        }
    }
}
