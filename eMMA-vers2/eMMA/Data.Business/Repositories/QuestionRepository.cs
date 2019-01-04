using System;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly DataLayer.AppContext _context;

        public QuestionRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Question entity)
        {
            _context.Questions.Add(entity);
        }

        public void Delete(Question entity)
        {
            _context.Questions.Remove(entity);
        }

        public void Edit(Question entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Question> FindBy(Expression<Func<Question, bool>> predicate)
        {
            return _context.Questions.Where(predicate);
        }

        public IQueryable<Question> GetAll()
        {
            return _context.Questions;
        }

        public Question GetSingle(Guid questionId)
        {
            return _context.Questions.Find(questionId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

