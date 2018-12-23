using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class ObjectRepository : IRepository<DataLayer.Models.Object>
    {
        private readonly DataLayer.AppContext _context;

        public ObjectRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(DataLayer.Models.Object entity)
        {
            _context.Objects.Add(entity);
        }

        public void Delete(DataLayer.Models.Object entity)
        {
            _context.Objects.Remove(entity);
        }

        public void Edit(DataLayer.Models.Object entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<DataLayer.Models.Object> FindBy(Expression<Func<DataLayer.Models.Object, bool>> predicate)
        {
            return _context.Objects.Where(predicate);
        }

        public IQueryable<DataLayer.Models.Object> GetAll()
        {
            return _context.Objects;
        }

        public DataLayer.Models.Object GetSingle(int objectId)
        {
            return _context.Objects.Find(objectId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
