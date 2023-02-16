using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Infrastructure;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
       //void Add(ArticleCategory category);
       //List<ArticleCategory> GetAll();
       //ArticleCategory Get(long id);
       //void Save();
       //bool Exists(string title);
    }
}
