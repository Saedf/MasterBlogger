using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Service
{
    public class ArticleCategoryValidationService: IArticleCategoryValidationService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidationService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckedRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(x=>x.Title==title))
            {
                throw new DuplicatedRecordException("This record already exists in database");
            }
        }
    }
}
