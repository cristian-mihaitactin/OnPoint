using System;
using System.Linq;
using System.Linq.Expressions;
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

        public override void Add(SeminarInstance entity)
        {
            _context.Seminars.Add(entity);
        }

        public override void Delete(SeminarInstance entity)
        {
            _context.Seminars.Remove(entity);
        }

        public override void Edit(SeminarInstance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<SeminarInstance> FindBy(Expression<Func<SeminarInstance, bool>> predicate)
        {
            return _context.Seminars.Where(predicate);
        }

        public override IQueryable<SeminarInstance> GetAll()
        {
            return _context.Seminars;
        }

        public override SeminarInstance GetSingle(Guid seminarId)
        {
            return _context.Seminars.Find(seminarId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
