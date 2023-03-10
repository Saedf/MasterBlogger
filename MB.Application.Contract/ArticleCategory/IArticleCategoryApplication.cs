using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> list();
        void Create(CreateArticleCategoryCommand command);
        void Rename(RenameArticleCategoryCommand command);
        RenameArticleCategoryCommand Get(long id);
        void Delete(long id);
        void Activate(long id);



    }
}
