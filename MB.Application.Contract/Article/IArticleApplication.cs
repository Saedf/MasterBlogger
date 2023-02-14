namespace MB.Application.Contract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle Get(long id);
        void Delete(long id);
        void Activate(long id);


    }
}
