using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class ProfessorRepository : eMMARepositoryBase<Professor, Guid>
    {
        private readonly eMMADbContext _context;

        public ProfessorRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(Professor entity)
        {
            _context.Professors.Add(entity);
        }

        public override void Delete(Professor entity)
        {
            _context.Professors.Remove(entity);
        }

        public override void Edit(Professor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Professor> FindBy(Expression<Func<Professor, bool>> predicate)
        {
            return _context.Professors.Where(predicate);
        }

        public override IQueryable<Professor> GetAll()
        {
            return _context.Professors;
        }

        public override Professor GetSingle(Guid personId)
        {
            return _context.Professors.Find(personId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
