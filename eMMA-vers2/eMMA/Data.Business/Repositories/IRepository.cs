using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetSingle(Guid personId);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
