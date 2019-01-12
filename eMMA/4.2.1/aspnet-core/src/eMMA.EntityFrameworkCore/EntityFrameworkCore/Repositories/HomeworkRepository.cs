using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class HomeworkRepository : eMMARepositoryBase<Homework, Guid>
    {
        private readonly eMMADbContext _context;

        public HomeworkRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override Homework Insert(Homework entity)
        {
            var dbEntity = _context.Homeworks.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<Homework> InsertAsync(Homework entity)
        {
            var dbEntity = await _context.Homeworks.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(Homework entity)
        {
            var dbEntity = _context.Homeworks.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override Homework Update(Homework entity)
        {
            var dbEntity = _context.Homeworks.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<Homework> GetAllList(Expression<Func<Homework, bool>> predicate)
        {
            return _context.Homeworks.Where(predicate).ToList();
        }

        public override Task<List<Homework>> GetAllListAsync(Expression<Func<Homework, bool>> predicate)
        {
            return _context.Homeworks.Where(predicate).ToListAsync();
        }

        public override IQueryable<Homework> GetAll()
        {
            return _context.Homeworks;
        }

        public override Task<List<Homework>> GetAllListAsync()
        {
            return _context.Homeworks.ToListAsync();
        }

        public override Homework Get(Guid hwId)
        {
            return _context.Homeworks.Find(hwId);
        }

        public override Task<Homework> GetAsync(Guid hwId)
        {
            return _context.Homeworks.FindAsync(hwId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
