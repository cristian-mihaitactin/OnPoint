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
    public class LaboratoryRepository : eMMARepositoryBase<LaboratoryInstance, Guid>
    {
        private readonly eMMADbContext _context;

        public LaboratoryRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override LaboratoryInstance Insert(LaboratoryInstance entity)
        {
            var dbEntity = _context.Laboratories.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<LaboratoryInstance> InsertAsync(LaboratoryInstance entity)
        {
            var dbEntity = await _context.Laboratories.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(LaboratoryInstance entity)
        {
            var dbEntity = _context.Laboratories.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override LaboratoryInstance Update(LaboratoryInstance entity)
        {
            var dbEntity = _context.Laboratories.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<LaboratoryInstance> GetAllList(Expression<Func<LaboratoryInstance, bool>> predicate)
        {
            return _context.Laboratories.Where(predicate).ToList();
        }

        public override Task<List<LaboratoryInstance>> GetAllListAsync(Expression<Func<LaboratoryInstance, bool>> predicate)
        {
            return _context.Laboratories.Where(predicate).ToListAsync();
        }

        public override IQueryable<LaboratoryInstance> GetAll()
        {
            return _context.Laboratories;
        }

        public override Task<List<LaboratoryInstance>> GetAllListAsync()
        {
            return _context.Laboratories.ToListAsync();
        }

        public override LaboratoryInstance Get(Guid labId)
        {
            return _context.Laboratories.Find(labId);
        }

        public override Task<LaboratoryInstance> GetAsync(Guid labId)
        {
            return _context.Laboratories.FindAsync(labId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
