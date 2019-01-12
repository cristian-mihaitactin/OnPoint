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
    public class AnswerRepository : eMMARepositoryBase<Answer, Guid>
    {
        private readonly eMMADbContext _context;

        public AnswerRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override Answer Insert(Answer entity)
        {
            var dbEntity = _context.Answers.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<Answer> InsertAsync(Answer entity)
        {
            var dbEntity = await _context.Answers.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(Answer entity)
        {
            var dbEntity = _context.Answers.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override Answer Update(Answer entity)
        {
            var dbEntity = _context.Answers.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<Answer> GetAllList(Expression<Func<Answer, bool>> predicate)
        {
            return _context.Answers.Where(predicate).ToList();
        }

        public override Task<List<Answer>> GetAllListAsync(Expression<Func<Answer, bool>> predicate)
        {
            return _context.Answers.Where(predicate).ToListAsync();
        }

        public override IQueryable<Answer> GetAll()
        {
            return _context.Answers;
        }

        public override Task<List<Answer>> GetAllListAsync()
        {
            return _context.Answers.ToListAsync();
        }

        public override Answer Get(Guid answerId)
        {
            return _context.Answers.Find(answerId);
        }

        public override Task<Answer> GetAsync(Guid answerId)
        {
            return _context.Answers.FindAsync(answerId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

    }
}
