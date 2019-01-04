using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class SeminarRepository : IRepository<SeminarInstance>
    {
        private readonly DataLayer.AppContext _context;

        public SeminarRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(SeminarInstance entity)
        {
            _context.Seminars.Add(entity);
        }

        public void Delete(SeminarInstance entity)
        {
            _context.Seminars.Remove(entity);
        }

        public void Edit(SeminarInstance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<SeminarInstance> FindBy(Expression<Func<SeminarInstance, bool>> predicate)
        {
            return _context.Seminars.Where(predicate);
        }

        public IQueryable<SeminarInstance> GetAll()
        {
            return _context.Seminars;
        }

        public SeminarInstance GetSingle(Guid seminarId)
        {
            return _context.Seminars.Find(seminarId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
