using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class CourseRepository : IRepository<CourseInstance>
    {
        private readonly DataLayer.AppContext _context;

        public CourseRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(CourseInstance entity)
        {
            _context.Courses.Add(entity);
        }

        public void Delete(CourseInstance entity)
        {
            _context.Courses.Remove(entity);
        }

        public void Edit(CourseInstance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<CourseInstance> FindBy(Expression<Func<CourseInstance, bool>> predicate)
        {
            return _context.Courses.Where(predicate);
        }

        public IQueryable<CourseInstance> GetAll()
        {
            return _context.Courses;
        }

        public CourseInstance GetSingle(int courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
