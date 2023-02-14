using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Content, command.ArticleCategoryId);
            _articleRepository.Create(article);
            

        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Picture,
                command.PictureAlt,command.PictureTitle,command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Title = article.Title,
                ArticleCategoryId = article.ArticleCategoryId,
                Content = article.Content,
                Id = article.Id,
                Picture = article.Picture,
                PictureAlt = article.PictureAlt,
                PictureTitle = article.PictureTitle,
                ShortDescription = article.ShortDescription
            };

        }
    }
}
