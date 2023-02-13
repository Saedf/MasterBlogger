using MB.Application.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

     [BindProperty] public RenameArticleCategoryCommand Command { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            Command = _articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
             _articleCategoryApplication.Rename(Command);
             return RedirectToPage("./List");
        }
    }
}
