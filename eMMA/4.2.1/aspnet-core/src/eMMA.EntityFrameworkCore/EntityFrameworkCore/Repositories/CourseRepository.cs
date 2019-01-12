using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public override CourseInstance Insert(CourseInstance entity)
        {
            var dbEntity = _context.Courses.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<CourseInstance> InsertAsync(CourseInstance entity)
        {
            var dbEntity = await _context.Courses.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(CourseInstance entity)
        {
            var dbEntity = _context.Courses.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override CourseInstance Update(CourseInstance entity)
        {
            var dbEntity = _context.Courses.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<CourseInstance> GetAllList(Expression<Func<CourseInstance, bool>> predicate)
        {
            return _context.Courses.Where(predicate).ToList();
        }

        public override Task<List<CourseInstance>> GetAllListAsync(Expression<Func<CourseInstance, bool>> predicate)
        {
            return _context.Courses.Where(predicate).ToListAsync();
        }

        public override IQueryable<CourseInstance> GetAll()
        {
            return _context.Courses;
        }

        public override Task<List<CourseInstance>> GetAllListAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public override CourseInstance Get(Guid courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public override Task<CourseInstance> GetAsync(Guid courseId)
        {
            return _context.Courses.FindAsync(courseId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
