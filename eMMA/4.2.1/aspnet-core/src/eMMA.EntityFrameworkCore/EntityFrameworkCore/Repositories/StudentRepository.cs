using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using eMMA.EntityFrameworkCore;
using eMMA.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class StudentRepository : eMMARepositoryBase<Student, Guid>
    {
        private readonly eMMADbContext _context;

        public StudentRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }
        public override Student Insert(Student entity)
        {
            using (_context)
            {
                var dbEntity = _context.Students.Add(entity);
                dbEntity.State = EntityState.Added;
                Save();

                return dbEntity.Entity;
            }
        }

        public override async Task<Student> InsertAsync(Student entity)
        {
            using (_context)
            {
                var dbEntity = await _context.Students.AddAsync(entity);
                dbEntity.State = EntityState.Added;

                Save();

                return dbEntity.Entity;
            }
        }

        public override void Delete(Student entity)
        {
            using (_context)
            {
                var dbEntity = _context.Students.Remove(entity);
                dbEntity.State = EntityState.Deleted;
                Save();
            }
                
        }

        public override Student Update(Student entity)
        {
            using (_context)
            {
                var dbEntity = _context.Students.Update(entity);
                dbEntity.State = EntityState.Modified;
                Save();

                return dbEntity.Entity;
            }
            
        }

        public override List<Student> GetAllList(Expression<Func<Student, bool>> predicate)
        {
            using (_context)
            {
                return _context.Students.Where(predicate).ToList();
            }
        }

        public override Task<List<Student>> GetAllListAsync(Expression<Func<Student, bool>> predicate)
        {
            using (_context)
            {
                return _context.Students.Where(predicate).ToListAsync();

            }
        }

        public override IQueryable<Student> GetAll()
        {
            using (_context)
            {
                return _context.Students;
            }
        }

        public override Task<List<Student>> GetAllListAsync()
        {
            using (_context)
            {
                return _context.Students.ToListAsync();
            }
        }

        public override Student Get(Guid studentId)
        {
            using (_context)
            {
                return _context.Students.Find(studentId);

            }
        }

        public override Task<Student> GetAsync(Guid studentId)
        {
            using (_context)
            {
                return _context.Students.FindAsync(studentId);

            }
        }

        public override void Save()
        {
            using (_context)
            {
                _context.SaveChanges();
            }
        }

    }
}
