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
    public class ProfessorRepository : eMMARepositoryBase<Professor, Guid>
    {
        private readonly eMMADbContext _context;

        public ProfessorRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override Professor Insert(Professor entity)
        {
            var dbEntity = _context.Professors.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<Professor> InsertAsync(Professor entity)
        {
            var dbEntity = await _context.Professors.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(Professor entity)
        {
            var dbEntity = _context.Professors.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override Professor Update(Professor entity)
        {
            var dbEntity = _context.Professors.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<Professor> GetAllList(Expression<Func<Professor, bool>> predicate)
        {
            return _context.Professors.Where(predicate).ToList();
        }

        public override Task<List<Professor>> GetAllListAsync(Expression<Func<Professor, bool>> predicate)
        {
            return _context.Professors.Where(predicate).ToListAsync();
        }

        public override IQueryable<Professor> GetAll()
        {
            return _context.Professors;
        }

        public override Task<List<Professor>> GetAllListAsync()
        {
            return _context.Professors.ToListAsync();
        }

        public override Professor Get(Guid profesorId)
        {
            return _context.Professors.Find(profesorId);
        }

        public override Task<Professor> GetAsync(Guid profesorId)
        {
            return _context.Professors.FindAsync(profesorId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
