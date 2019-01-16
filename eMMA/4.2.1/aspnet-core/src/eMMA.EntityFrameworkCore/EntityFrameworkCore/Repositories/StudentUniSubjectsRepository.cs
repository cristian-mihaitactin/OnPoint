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
    public class StudentUniSubjectsRepository : eMMARepositoryBase<StudentUniSubjects, Guid>
    {
        private readonly eMMADbContext _context;

        public StudentUniSubjectsRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }
        public override StudentUniSubjects Insert(StudentUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = _context.StudentUniSubjects.Add(entity);
                dbEntity.State = EntityState.Added;
                Save();

                return dbEntity.Entity;
            }

        }

        public override async Task<StudentUniSubjects> InsertAsync(StudentUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = await _context.StudentUniSubjects.AddAsync(entity);
                dbEntity.State = EntityState.Added;

                Save();

                return dbEntity.Entity;
            }

        }

        public override void Delete(StudentUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = _context.StudentUniSubjects.Remove(entity);
                dbEntity.State = EntityState.Deleted;
                Save();
            }

        }

        public override StudentUniSubjects Update(StudentUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = _context.StudentUniSubjects.Update(entity);
                dbEntity.State = EntityState.Modified;
                Save();

                return dbEntity.Entity;
            }

        }

        public override List<StudentUniSubjects> GetAllList(Expression<Func<StudentUniSubjects, bool>> predicate)
        {
            using (_context)
            {
                return _context.StudentUniSubjects.Where(predicate).ToList();

            }
        }

        public override Task<List<StudentUniSubjects>> GetAllListAsync(Expression<Func<StudentUniSubjects, bool>> predicate)
        {
            using (_context)
            {
                return _context.StudentUniSubjects.Where(predicate).ToListAsync();

            }
        }

        public override IQueryable<StudentUniSubjects> GetAll()
        {
            using (_context)
            {
                return _context.StudentUniSubjects;

            }
        }

        public override Task<List<StudentUniSubjects>> GetAllListAsync()
        {
            using (_context)
            {
                return _context.StudentUniSubjects.ToListAsync();

            }
        }

        public override StudentUniSubjects Get(Guid StudentUniSubjectsId)
        {
            using (_context)
            {
                return _context.StudentUniSubjects.Find(StudentUniSubjectsId);

            }
        }

        public override Task<StudentUniSubjects> GetAsync(Guid StudentUniSubjectsId)
        {
            using (_context)
            {
                return _context.StudentUniSubjects.FindAsync(StudentUniSubjectsId);

            }
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

    }
}