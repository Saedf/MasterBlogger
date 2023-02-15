using MB.Infrastrucutre.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages.Shared
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> ArticleQueries { get; set; }
        private readonly IArticleQuery _articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet()
        {
            ArticleQueries = _articleQuery.GetArticles();
        }
    }
}
