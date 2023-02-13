using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
       void Add(ArticleCategory category);
       List<ArticleCategory> GetAll();
       ArticleCategory Get(long id);
       void Save();
       bool Exists(string title);
    }
}
