using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class ProfessorRepository:IRepository<Professor>
    {
        private readonly DataLayer.AppContext _context;

        public ProfessorRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Professor entity)
        {
            _context.Professors.Add(entity);
        }

        public void Delete(Professor entity)
        {
            _context.Professors.Remove(entity);
        }

        public void Edit(Professor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Professor> FindBy(Expression<Func<Professor, bool>> predicate)
        {
            return _context.Professors.Where(predicate);
        }

        public IQueryable<Professor> GetAll()
        {
            return _context.Professors;
        }

        public Professor GetSingle(Guid personId)
        {
            return _context.Professors.Find(personId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
