using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using eMMA.EntityFrameworkCore;
using eMMA.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class StudentRepository : eMMARepositoryBase<Student, Guid>
    {
        private readonly eMMADbContext _context;

        public StudentRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(Student entity)
        {
            _context.Students.Add(entity);
        }

        public override void Delete(Student entity)
        {
            _context.Students.Remove(entity);
        }

        public override void Edit(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Student> FindBy(Expression<Func<Student, bool>> predicate)
        {
            return _context.Students.Where(predicate);
        }

        public override IQueryable<Student> GetAll()
        {
            return _context.Students;
        }

        public override Student GetSingle(Guid personId)
        {
            return _context.Students.Find(personId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
