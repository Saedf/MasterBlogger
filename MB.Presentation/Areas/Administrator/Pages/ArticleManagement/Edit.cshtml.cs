using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<SelectListItem> ArticleCategories { get; set; }
        [BindProperty] public EditArticle EditArticle { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet(long id)
        {
            EditArticle = _articleApplication.Get(id);
            ArticleCategories = _articleCategoryApplication.list().Select(
                x=>new SelectListItem(x.Title,x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(EditArticle);
            return RedirectToPage("./List");
        }
    }
}
