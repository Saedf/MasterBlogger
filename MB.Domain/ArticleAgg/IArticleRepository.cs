using MB.Application.Contract.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void Create(Article article);

        Article Get(long id);

        void Save();
        // void Update(Article article);
    }
}
