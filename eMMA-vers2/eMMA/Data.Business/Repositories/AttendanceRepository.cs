using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class AttendanceRepository : IRepository<Attendance>
    {
        private readonly DataLayer.AppContext _context;

        public AttendanceRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Attendance entity)
        {
            _context.Attendances.Add(entity);
        }

        public void Delete(Attendance entity)
        {
            _context.Attendances.Remove(entity);
        }

        public void Edit(Attendance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Attendance> FindBy(Expression<Func<Attendance, bool>> predicate)
        {
            return _context.Attendances.Where(predicate);
        }

        public IQueryable<Attendance> GetAll()
        {
            return _context.Attendances;
        }

        public Attendance GetSingle(int personId)
        {
            return _context.Attendances.Find(personId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
