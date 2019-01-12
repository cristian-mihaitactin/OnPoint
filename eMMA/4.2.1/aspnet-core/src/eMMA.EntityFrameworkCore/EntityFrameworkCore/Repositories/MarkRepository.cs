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
    public class MarkRepository : eMMARepositoryBase<Mark, Guid>
    {
        private readonly eMMADbContext _context;

        public MarkRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }
        public override Mark Insert(Mark entity)
        {
            var dbEntity = _context.Marks.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<Mark> InsertAsync(Mark entity)
        {
            var dbEntity = await _context.Marks.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(Mark entity)
        {
            var dbEntity = _context.Marks.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override Mark Update(Mark entity)
        {
            var dbEntity = _context.Marks.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<Mark> GetAllList(Expression<Func<Mark, bool>> predicate)
        {
            return _context.Marks.Where(predicate).ToList();
        }

        public override Task<List<Mark>> GetAllListAsync(Expression<Func<Mark, bool>> predicate)
        {
            return _context.Marks.Where(predicate).ToListAsync();
        }

        public override IQueryable<Mark> GetAll()
        {
            return _context.Marks;
        }

        public override Task<List<Mark>> GetAllListAsync()
        {
            return _context.Marks.ToListAsync();
        }

        public override Mark Get(Guid markId)
        {
            return _context.Marks.Find(markId);
        }

        public override Task<Mark> GetAsync(Guid markId)
        {
            return _context.Marks.FindAsync(markId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
