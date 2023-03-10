using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using _01_FrameWork.Infrastructure;
using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Repositories
{
    public class ArticleRepository :BaseRepository<long,Article>,IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context):base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x=>x.ArticleCategory)
                .Select(x=> new ArticleViewModel
                {
                    Id =x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    IsDelete = x.IsDeleted

                }).OrderByDescending(x=>x.Id)
                .ToList();
        }

        //public void Create(Article article)
        //{
        //    _context.Articles.Add(article);
        //    Save();
        //}

        //public Article Get(long id)
        //{
        //    return _context.Articles.FirstOrDefault(x => x.Id == id);
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        //public bool Exists(string title)
        //{
        //    return _context.Articles.Any(x => x.Title==title);
        //}
    }
}
