using System;
using System.Linq;
using System.Linq.Expressions;
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

        public override void Add(File entity)
        {
            _context.Files.Add(entity);
        }

        public override void Delete(File entity)
        {
            _context.Files.Remove(entity);
        }

        public override void Edit(File entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<File> FindBy(Expression<Func<File, bool>> predicate)
        {
            return _context.Files.Where(predicate);
        }

        public override IQueryable<File> GetAll()
        {
            return _context.Files;
        }

        public override File GetSingle(Guid idFile)
        {
            return _context.Files.Find(idFile);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
