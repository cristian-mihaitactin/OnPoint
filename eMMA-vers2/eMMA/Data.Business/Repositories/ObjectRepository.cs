using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class UniClassRepository : IRepository<DataLayer.Models.UniClass>
    {
        private readonly DataLayer.AppContext _context;

        public UniClassRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(DataLayer.Models.UniClass entity)
        {
            _context.UniClasses.Add(entity);
        }

        public void Delete(DataLayer.Models.UniClass entity)
        {
            _context.UniClasses.Remove(entity);
        }

        public void Edit(DataLayer.Models.UniClass entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<DataLayer.Models.UniClass> FindBy(Expression<Func<DataLayer.Models.UniClass, bool>> predicate)
        {
            return _context.UniClasses.Where(predicate);
        }

        public IQueryable<DataLayer.Models.UniClass> GetAll()
        {
            return _context.UniClasses;
        }

        public DataLayer.Models.UniClass GetSingle(int UniClassId)
        {
            return _context.UniClasses.Find(UniClassId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
