using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        // public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        // public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
            
        }

        public ArticleCategory(string title, IArticleCategoryValidationService articleCategoryValidationService)
        {
            GuardAgainstEmptyTitle(title);
            articleCategoryValidationService.CheckedRecordAlreadyExists(title);
            Title = title;
            IsDeleted = false;
        //    CreationDate=DateTime.Now;
            Articles = new List<Article>();
        }

        private static void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
        }

        public void Rename(string title)
        {

            GuardAgainstEmptyTitle(title);
            Title =title;
        }

        public void Delete()
        {
            IsDeleted=true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
