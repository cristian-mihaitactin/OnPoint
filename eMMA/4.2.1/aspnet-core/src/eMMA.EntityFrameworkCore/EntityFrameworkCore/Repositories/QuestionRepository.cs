using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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


        public override Question Insert(Question entity)
        {
            var dbEntity = _context.Questions.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<Question> InsertAsync(Question entity)
        {
            var dbEntity = await _context.Questions.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(Question entity)
        {
            var dbEntity = _context.Questions.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override Question Update(Question entity)
        {
            var dbEntity = _context.Questions.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<Question> GetAllList(Expression<Func<Question, bool>> predicate)
        {
            return _context.Questions.Where(predicate).ToList();
        }

        public override Task<List<Question>> GetAllListAsync(Expression<Func<Question, bool>> predicate)
        {
            return _context.Questions.Where(predicate).ToListAsync();
        }

        public override IQueryable<Question> GetAll()
        {
            return _context.Questions;
        }

        public override Task<List<Question>> GetAllListAsync()
        {
            return _context.Questions.ToListAsync();
        }

        public override Question Get(Guid questionId)
        {
            return _context.Questions.Find(questionId);
        }

        public override Task<Question> GetAsync(Guid questionId)
        {
            return _context.Questions.FindAsync(questionId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}

