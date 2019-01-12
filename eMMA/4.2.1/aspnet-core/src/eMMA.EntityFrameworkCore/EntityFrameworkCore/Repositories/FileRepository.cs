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
    public class FileRepository : eMMARepositoryBase<File, Guid>
    {
        private readonly eMMADbContext _context;

        public FileRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override File Insert(File entity)
        {
            var dbEntity = _context.Files.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<File> InsertAsync(File entity)
        {
            var dbEntity = await _context.Files.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(File entity)
        {
            var dbEntity = _context.Files.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override File Update(File entity)
        {
            var dbEntity = _context.Files.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<File> GetAllList(Expression<Func<File, bool>> predicate)
        {
            return _context.Files.Where(predicate).ToList();
        }

        public override Task<List<File>> GetAllListAsync(Expression<Func<File, bool>> predicate)
        {
            return _context.Files.Where(predicate).ToListAsync();
        }

        public override IQueryable<File> GetAll()
        {
            return _context.Files;
        }

        public override Task<List<File>> GetAllListAsync()
        {
            return _context.Files.ToListAsync();
        }

        public override File Get(Guid fileId)
        {
            return _context.Files.Find(fileId);
        }

        public override Task<File> GetAsync(Guid fileId)
        {
            return _context.Files.FindAsync(fileId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
