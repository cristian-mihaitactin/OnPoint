using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class UniClassRepository : IRepository<UniClass>
    {
        private readonly DataLayer.AppContext _context;

        public UniClassRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(UniClass entity)
        {
            _context.UniClasses.Add(entity);
        }

        public void Delete(UniClass entity)
        {
            _context.UniClasses.Remove(entity);
        }

        public void Edit(UniClass entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<UniClass> FindBy(Expression<Func<UniClass, bool>> predicate)
        {
            return _context.UniClasses.Where(predicate);
        }

        public IQueryable<UniClass> GetAll()
        {
            return _context.UniClasses;
        }

        public UniClass GetSingle(int UniClassId)
        {
            return _context.UniClasses.Find(UniClassId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
