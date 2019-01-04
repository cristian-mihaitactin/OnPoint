using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class AnswerRepository:IRepository<Answer>
    {
        private readonly DataLayer.AppContext _context;

        public AnswerRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Answer entity)
        {
            _context.Answers.Add(entity);
        }

        public void Delete(Answer entity)
        {
            _context.Answers.Remove(entity);
        }

        public void Edit(Answer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Answer> FindBy(Expression<Func<Answer, bool>> predicate)
        {
            return _context.Answers.Where(predicate);
        }

        public IQueryable<Answer> GetAll()
        {
            return _context.Answers;
        }

        public Answer GetSingle(Guid answerId)
        {
            return _context.Answers.Find(answerId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
