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
    public class AttendanceRepository : eMMARepositoryBase<Attendance, Guid>
    {
        private readonly eMMADbContext _context;

        public AttendanceRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override Attendance Insert(Attendance entity)
        {
            var dbEntity = _context.Attendances.Add(entity);
            dbEntity.State = EntityState.Added;
            Save();

            return dbEntity.Entity;
        }

        public override async Task<Attendance> InsertAsync(Attendance entity)
        {
            var dbEntity = await _context.Attendances.AddAsync(entity);
            dbEntity.State = EntityState.Added;

            Save();

            return dbEntity.Entity;
        }

        public override void Delete(Attendance entity)
        {
            var dbEntity = _context.Attendances.Remove(entity);
            dbEntity.State = EntityState.Deleted;
            Save();
        }

        public override Attendance Update(Attendance entity)
        {
            var dbEntity = _context.Attendances.Update(entity);
            dbEntity.State = EntityState.Modified;
            Save();

            return dbEntity.Entity;
        }

        public override List<Attendance> GetAllList(Expression<Func<Attendance, bool>> predicate)
        {
            return _context.Attendances.Where(predicate).ToList();
        }

        public override Task<List<Attendance>> GetAllListAsync(Expression<Func<Attendance, bool>> predicate)
        {
            return _context.Attendances.Where(predicate).ToListAsync();
        }

        public override IQueryable<Attendance> GetAll()
        {
            return _context.Attendances;
        }

        public override Task<List<Attendance>> GetAllListAsync()
        {
            return _context.Attendances.ToListAsync();
        }

        public override Attendance Get(Guid attendanceId)
        {
            return _context.Attendances.Find(attendanceId);
        }

        public override Task<Attendance> GetAsync(Guid attendanceId)
        {
            return _context.Attendances.FindAsync(attendanceId);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
