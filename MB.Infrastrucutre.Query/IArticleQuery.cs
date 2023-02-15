namespace MB.Infrastrucutre.Query;

public interface IArticleQuery
{
    List<ArticleQueryView> GetArticles();
    ArticleQueryView GetArticle(long id);
}