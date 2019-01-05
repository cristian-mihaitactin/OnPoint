using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class UniSubjectRepository : eMMARepositoryBase<UniSubject, Guid>
    {
        private readonly eMMADbContext _context;

        public UniSubjectRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(UniSubject entity)
        {
            _context.UniSubjects.Add(entity);
        }

        public override void Delete(UniSubject entity)
        {
            _context.UniSubjects.Remove(entity);
        }

        public override void Edit(UniSubject entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<UniSubject> FindBy(Expression<Func<UniSubject, bool>> predicate)
        {
            return _context.UniSubjects.Where(predicate);
        }

        public override IQueryable<UniSubject> GetAll()
        {
            return _context.UniSubjects;
        }

        public override UniSubject GetSingle(Guid subjectId)
        {
            return _context.UniSubjects.Find(subjectId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}