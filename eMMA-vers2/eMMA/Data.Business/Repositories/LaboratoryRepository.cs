using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class LaboratoryRepository : IRepository<LaboratoryInstance>
    {
        private readonly DataLayer.AppContext _context;

        public LaboratoryRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(LaboratoryInstance entity)
        {
            _context.Laboratories.Add(entity);
        }

        public void Delete(LaboratoryInstance entity)
        {
            _context.Laboratories.Remove(entity);
        }

        public void Edit(LaboratoryInstance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<LaboratoryInstance> FindBy(Expression<Func<LaboratoryInstance, bool>> predicate)
        {
            return _context.Laboratories.Where(predicate);
        }

        public IQueryable<LaboratoryInstance> GetAll()
        {
            return _context.Laboratories;
        }

        public LaboratoryInstance GetSingle(int labId)
        {
            return _context.Laboratories.Find(labId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
