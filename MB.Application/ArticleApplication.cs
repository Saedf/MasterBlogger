using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorServices _articleValidatorServices;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorServices articleValidatorServices)
        {
            _articleRepository = articleRepository;
            _articleValidatorServices = articleValidatorServices;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Content, command.ArticleCategoryId,_articleValidatorServices);
            _articleRepository.Create(article);
            _articleRepository.Save();
            

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

        public void Delete(long id)
        {
            var article = _articleRepository.Get(id);
            article.Delete(article.Id);
            _articleRepository.Save();
        }

        public void Activate(long id)
        {
            var article = _articleRepository.Get(id);
            article.Activate(article.Id);
            _articleRepository.Save();

        }
    }
}
