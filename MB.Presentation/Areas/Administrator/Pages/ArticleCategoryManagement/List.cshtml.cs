using MB.Application.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _categoryApplication;

        public ListModel(IArticleCategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _categoryApplication.list();
        }

        public RedirectToPageResult OnPostDelete(long id)
        {
            _categoryApplication.Delete(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostActivate(long id)
        {
            _categoryApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
