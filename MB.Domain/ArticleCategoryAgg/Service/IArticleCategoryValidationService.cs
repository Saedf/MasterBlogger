using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Service
{
    public interface IArticleCategoryValidationService
    {
        void CheckedRecordAlreadyExists(string title);
    }
}
