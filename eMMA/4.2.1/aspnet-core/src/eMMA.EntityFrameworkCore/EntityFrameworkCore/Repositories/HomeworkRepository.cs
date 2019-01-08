using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class HomeworkRepository : eMMARepositoryBase<Homework, Guid>
    {
        private readonly eMMADbContext _context;

        public HomeworkRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(Homework entity)
        {
            _context.Homeworks.Add(entity);
        }

        public override void Delete(Homework entity)
        {
            _context.Homeworks.Remove(entity);
        }

        public override void Edit(Homework entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Homework> FindBy(Expression<Func<Homework, bool>> predicate)
        {
            return _context.Homeworks.Where(predicate);
        }

        public override IQueryable<Homework> GetAll()
        {
            return _context.Homeworks;
        }

        public override Homework GetSingle(Guid personId)
        {
            return _context.Homeworks.Find(personId);
        }
        
        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
