using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class QuestionRepository : eMMARepositoryBase<Question, Guid>
    {
        private readonly eMMADbContext _context;

        public QuestionRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(Question entity)
        {
            _context.Questions.Add(entity);
        }

        public override void Delete(Question entity)
        {
            _context.Questions.Remove(entity);
        }

        public override void Edit(Question entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Question> FindBy(Expression<Func<Question, bool>> predicate)
        {
            return _context.Questions.Where(predicate);
        }

        public override IQueryable<Question> GetAll()
        {
            return _context.Questions;
        }

        public override Question GetSingle(Guid questionId)
        {
            return _context.Questions.Find(questionId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}

