using MB.Infrastrucutre.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView ArticleQueryView { get; set; }
        private readonly IArticleQuery _articleQuery;

        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            ArticleQueryView = _articleQuery.GetArticle(id);
        }
    }
}
