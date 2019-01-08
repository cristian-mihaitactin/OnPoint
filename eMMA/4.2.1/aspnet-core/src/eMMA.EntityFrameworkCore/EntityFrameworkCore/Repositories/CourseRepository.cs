using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class CourseRepository : eMMARepositoryBase<CourseInstance, Guid>
    {
        private readonly eMMADbContext _context;

        public CourseRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(CourseInstance entity)
        {
            _context.Courses.Add(entity);
        }

        public override void Delete(CourseInstance entity)
        {
            _context.Courses.Remove(entity);
        }

        public override void Edit(CourseInstance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<CourseInstance> FindBy(Expression<Func<CourseInstance, bool>> predicate)
        {
            return _context.Courses.Where(predicate);
        }

        public override IQueryable<CourseInstance> GetAll()
        {
            return _context.Courses;
        }

        public override CourseInstance GetSingle(Guid courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
