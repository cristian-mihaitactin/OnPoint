using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class UniSubjectRepository : IRepository<UniSubject>
    {
        private readonly DataLayer.AppContext _context;

        public UniSubjectRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(UniSubject entity)
        {
            _context.UniSubjects.Add(entity);
        }

        public void Delete(UniSubject entity)
        {
            _context.UniSubjects.Remove(entity);
        }

        public void Edit(UniSubject entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<UniSubject> FindBy(Expression<Func<UniSubject, bool>> predicate)
        {
            return _context.UniSubjects.Where(predicate);
        }

        public IQueryable<UniSubject> GetAll()
        {
            return _context.UniSubjects;
        }

        public UniSubject GetSingle(int subjectId)
        {
            return _context.UniSubjects.Find(subjectId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}