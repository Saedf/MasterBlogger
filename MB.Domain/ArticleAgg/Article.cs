using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
            
        }

        public Article(string title, string shortDescription, string picture, string pictureAlt, string pictureTitle, string content, long articleCategoryId,
            IArticleValidatorServices articleValidatorServices)
        {
            Validate(title, articleCategoryId);
            articleValidatorServices.CheckedThatThisRecordAlreadyExists(title);
            Title = title;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            CreationDate=DateTime.Now;
            IsDeleted = false;
        }

        private static void Validate(string title, long articleCategoryId)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException();
            }

            if (articleCategoryId == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Edit(string title, string shortDescription, string picture, string pictureAlt, string pictureTitle, string content, long articleCategoryId)
        {
            Validate(title,articleCategoryId);
            Title = title;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Content = content;
            ArticleCategoryId = articleCategoryId;


        }

        public void Delete(long id)
        {
            IsDeleted = true;
        }

       public void Activate(long id)
        {
            IsDeleted=false;
        }
    }
}
