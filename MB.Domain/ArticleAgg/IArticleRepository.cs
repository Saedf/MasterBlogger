using _01_FrameWork.Infrastructure;
using MB.Application.Contract.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
        //void Create(Article article);

        //Article Get(long id);

        //void Save();
        //bool Exists(string title);
    }
}
