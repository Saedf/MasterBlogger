using MB.Application.Contract.Comment;
using MB.Infrastrucutre.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView ArticleQueryView { get; set; }
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            ArticleQueryView = _articleQuery.GetArticle(id);
        }

        public RedirectToPageResult OnPost(AddComment comment)
        {
            _commentApplication.Add(comment);
            return RedirectToPage("./ArticleDetails",new {id=comment.ArticleId});
        }
    }
}
