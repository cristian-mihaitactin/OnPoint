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
    public class UniSubjectRepository : eMMARepositoryBase<UniSubject, Guid>
    {
        private readonly eMMADbContext _context;

        public UniSubjectRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override UniSubject Insert(UniSubject entity)
        {
            var dbEntity = _context.UniSubjects.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<UniSubject> InsertAsync(UniSubject entity)
        {
            var dbEntity = await _context.UniSubjects.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(UniSubject entity)
        {
            var dbEntity = _context.UniSubjects.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override UniSubject Update(UniSubject entity)
        {
            var dbEntity = _context.UniSubjects.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<UniSubject> GetAllList(Expression<Func<UniSubject, bool>> predicate)
        {
            return _context.UniSubjects.Where(predicate).ToList();
        }

        public override Task<List<UniSubject>> GetAllListAsync(Expression<Func<UniSubject, bool>> predicate)
        {
            return _context.UniSubjects.Where(predicate).ToListAsync();
        }

        public override IQueryable<UniSubject> GetAll()
        {
            return _context.UniSubjects;
        }

        public override Task<List<UniSubject>> GetAllListAsync()
        {
            return _context.UniSubjects.ToListAsync();
        }

        public override UniSubject Get(Guid subjectId)
        {
            return _context.UniSubjects.Find(subjectId);
        }
        
        public override Task<UniSubject> GetAsync(Guid subjectId)
        {
            return _context.UniSubjects.FindAsync(subjectId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
        
    }
}