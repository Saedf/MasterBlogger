using MB.Application.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public List<ArticleViewModel> Articles { get; set; }
        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }
    }
}
