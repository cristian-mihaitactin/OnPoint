using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class AttendanceRepository : eMMARepositoryBase<Attendance, Guid>
    {
        private readonly eMMADbContext _context;

        public AttendanceRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override void Add(Attendance entity)
        {
            _context.Attendances.Add(entity);
        }

        public override void Delete(Attendance entity)
        {
            _context.Attendances.Remove(entity);
        }

        public override void Edit(Attendance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<Attendance> FindBy(Expression<Func<Attendance, bool>> predicate)
        {
            return _context.Attendances.Where(predicate);
        }

        public override IQueryable<Attendance> GetAll()
        {
            return _context.Attendances;
        }

        public override Attendance GetSingle(Guid personId)
        {
            return _context.Attendances.Find(personId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
