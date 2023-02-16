using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Infrastructure;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;
using MB.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidationService _articleCategoryValidationService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidationService articleCategoryValidationService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidationService = articleCategoryValidationService;
            _unitOfWork = unitOfWork;
        }


        public List<ArticleCategoryViewModel> list()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result=new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title =articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture),
                });
            }

            return result;
        }

        public void Create(CreateArticleCategoryCommand command)
        {
            _unitOfWork.BeginTran();
            var articleCategory=new ArticleCategory(command.Title,_articleCategoryValidationService);
            _articleCategoryRepository.Create(articleCategory);
            // _articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategoryCommand command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            // _articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }


        public RenameArticleCategoryCommand Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategoryCommand
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title

            };
        }

        public void Delete(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Delete();
            // _articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }


        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
        
            _unitOfWork.CommitTran();// _articleCategoryRepository.Save();
        }

    }
}
