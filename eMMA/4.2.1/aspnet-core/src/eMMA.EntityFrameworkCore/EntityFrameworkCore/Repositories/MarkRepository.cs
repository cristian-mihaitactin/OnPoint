using System;
using System.Linq;
using System.Linq.Expressions;
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

        public override void Add(Mark entity)
        {
            _context.Marks.Add(entity);
        }

        public override void Delete(Mark entity)
        {
            _context.Marks.Remove(entity);
        }

        public override void Edit(Mark entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Mark> FindBy(Expression<Func<Mark, bool>> predicate)
        {
            return _context.Marks.Where(predicate);
        }

        public override IQueryable<Mark> GetAll()
        {
            return _context.Marks;
        }

        public override Mark GetSingle(Guid studentId)
        {
            return _context.Marks.Find(studentId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
