using System.Globalization;
using MB.Domain.CommentAgg;
using MB.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastrucutre.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x=>x.Comments)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                CommentCount = x.Comments.Count(x=>x.Status==Statuses.Confirmed),
                //Comments = MapComments(x.Comments)
            }).OrderByDescending(x => x.Id).ToList();
    }

    private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
    {
        return comments.Where(x => x.Status == Statuses.Confirmed)
            .Select(x=>new CommentQueryView
        {
            Name = x.Name,
            Message = x.Message,
            CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
            
        }).ToList();
    }

    public ArticleQueryView? GetArticle(long id)
    {
        return _context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x=>x.Comments)         
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                Content = x.Content,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentCount = x.Comments.Count(x=>x.Status==Statuses.Confirmed),
                Comments=MapComments(x.Comments.Where(z=>z.Status==Statuses.Confirmed))

            }).FirstOrDefault(x=>x.Id==id);
    }
}