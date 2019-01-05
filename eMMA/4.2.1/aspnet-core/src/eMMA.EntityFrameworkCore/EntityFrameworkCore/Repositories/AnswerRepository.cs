using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class AnswerRepository : eMMARepositoryBase<Answer, Guid>
    {
        private readonly eMMADbContext _context;

        public AnswerRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(Answer entity)
        {
            _context.Answers.Add(entity);
        }

        public override void Delete(Answer entity)
        {
            _context.Answers.Remove(entity);
        }

        public override void Edit(Answer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Answer> FindBy(Expression<Func<Answer, bool>> predicate)
        {
            return _context.Answers.Where(predicate);
        }

        public override IQueryable<Answer> GetAll()
        {
            return _context.Answers;
        }

        public override Answer GetSingle(Guid answerId)
        {
            return _context.Answers.Find(answerId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
