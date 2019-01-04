using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly DataLayer.AppContext _context;

        public StudentRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);
        }

        public void Edit(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Student> FindBy(Expression<Func<Student, bool>> predicate)
        {
            return _context.Students.Where(predicate);
        }

        public IQueryable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetSingle(Guid personId)
        {
            return _context.Students.Find(personId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
