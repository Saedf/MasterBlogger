using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_FrameWork.Infrastructure
{
    public class BaseRepository<TKey,T>: IRepository<TKey,T> where T : DomainBase<TKey>
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public T Get(TKey id)
        {
            return _dbContext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().OrderByDescending(x=>x.Id).ToList();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            // return _context.ArticleCategories.Any(x => x.Title == title);
            return _dbContext.Set<T>().Any(expression);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
