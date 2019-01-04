using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class FileRepository : IRepository<File>
    {
        private readonly DataLayer.AppContext _context;

        public FileRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(File entity)
        {
            _context.Files.Add(entity);
        }

        public void Delete(File entity)
        {
            _context.Files.Remove(entity);
        }

        public void Edit(File entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<File> FindBy(Expression<Func<File, bool>> predicate)
        {
            return _context.Files.Where(predicate);
        }

        public IQueryable<File> GetAll()
        {
            return _context.Files;
        }

        public File GetSingle(Guid idFile)
        {
            return _context.Files.Find(idFile);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
