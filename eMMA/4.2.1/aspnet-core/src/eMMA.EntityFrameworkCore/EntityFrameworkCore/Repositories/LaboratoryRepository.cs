using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class LaboratoryRepository : eMMARepositoryBase<LaboratoryInstance, Guid>
    {
        private readonly eMMADbContext _context;

        public LaboratoryRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(LaboratoryInstance entity)
        {
            _context.Laboratories.Add(entity);
        }
        
        public override void Delete(LaboratoryInstance entity)
        {
            _context.Laboratories.Remove(entity);
        }

        public override void Edit(LaboratoryInstance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<LaboratoryInstance> FindBy(Expression<Func<LaboratoryInstance, bool>> predicate)
        {
            return _context.Laboratories.Where(predicate);
        }

        public override IQueryable<LaboratoryInstance> GetAll()
        {
            return _context.Laboratories;
        }
        
        public override LaboratoryInstance GetSingle(Guid labId)
        {
            return _context.Laboratories.Find(labId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
