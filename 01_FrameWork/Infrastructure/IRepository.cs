using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Domain;

namespace _01_FrameWork.Infrastructure
{
    public interface IRepository<in Tkey,T> where T:DomainBase<Tkey>
    {
        void Create(T entity);
        T Get(Tkey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T,bool>> expression);
        void Save();

    }
}
