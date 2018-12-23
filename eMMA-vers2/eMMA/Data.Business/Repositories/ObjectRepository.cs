using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class ObjectRepository : IRepository<Object>
    {
        private readonly DataLayer.AppContext _context;

        public ObjectRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Object entity)
        {
            _context.Objects.Add(entity);
        }

        public void Delete(Object entity)
        {
            _context.Objects.Remove(entity);
        }

        public void Edit(Object entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Object> FindBy(Expression<Func<Object, bool>> predicate)
        {
            return _context.Objects.Where(predicate);
        }

        public IQueryable<Object> GetAll()
        {
            return _context.Objects;
        }

        public Object GetSingle(int objectId)
        {
            return _context.Objects.Find(objectId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
