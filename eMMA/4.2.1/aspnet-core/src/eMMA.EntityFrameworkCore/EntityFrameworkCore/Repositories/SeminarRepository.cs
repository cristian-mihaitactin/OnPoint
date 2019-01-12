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
    public class SeminarRepository : eMMARepositoryBase<SeminarInstance, Guid>
    {
        private readonly eMMADbContext _context;

        public SeminarRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }


        public override SeminarInstance Insert(SeminarInstance entity)
        {
            var dbEntity = _context.Seminars.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<SeminarInstance> InsertAsync(SeminarInstance entity)
        {
            var dbEntity = await _context.Seminars.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(SeminarInstance entity)
        {
            var dbEntity = _context.Seminars.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override SeminarInstance Update(SeminarInstance entity)
        {
            var dbEntity = _context.Seminars.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<SeminarInstance> GetAllList(Expression<Func<SeminarInstance, bool>> predicate)
        {
            return _context.Seminars.Where(predicate).ToList();
        }

        public override Task<List<SeminarInstance>> GetAllListAsync(Expression<Func<SeminarInstance, bool>> predicate)
        {
            return _context.Seminars.Where(predicate).ToListAsync();
        }

        public override IQueryable<SeminarInstance> GetAll()
        {
            return _context.Seminars;
        }

        public override Task<List<SeminarInstance>> GetAllListAsync()
        {
            return _context.Seminars.ToListAsync();
        }

        public override SeminarInstance Get(Guid seminarId)
        {
            return _context.Seminars.Find(seminarId);
        }

        public override Task<SeminarInstance> GetAsync(Guid seminarId)
        {
            return _context.Seminars.FindAsync(seminarId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
