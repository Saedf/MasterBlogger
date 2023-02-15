using System.Globalization;
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
        return _context.Articles.Include(x => x.ArticleCategory)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture)
            }).OrderByDescending(x => x.Id).ToList();
    }

    public ArticleQueryView GetArticle(long id)
    {
        return _context.Articles.Include(x => x.ArticleCategory)
           
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                Content = x.Content,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).FirstOrDefault(x=>x.Id==id);
    }
}