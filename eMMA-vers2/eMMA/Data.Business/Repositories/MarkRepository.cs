using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class MarkRepository : IRepository<Mark>
    {
        private readonly DataLayer.AppContext _context;

        public MarkRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Mark entity)
        {
            _context.Marks.Add(entity);
        }

        public void Delete(Mark entity)
        {
            _context.Marks.Remove(entity);
        }

        public void Edit(Mark entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Mark> FindBy(Expression<Func<Mark, bool>> predicate)
        {
            return _context.Marks.Where(predicate);
        }

        public IQueryable<Mark> GetAll()
        {
            return _context.Marks;
        }

        public Mark GetSingle(int studentId)
        {
            return _context.Marks.Find(studentId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
