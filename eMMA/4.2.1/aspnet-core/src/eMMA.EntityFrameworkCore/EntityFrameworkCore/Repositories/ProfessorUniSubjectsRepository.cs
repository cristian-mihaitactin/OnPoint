using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using eMMA.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore.Repositories
{
    public class ProfessorUniSubjectsRepository : eMMARepositoryBase<ProfessorUniSubjects, Guid>
    {
        private readonly eMMADbContext _context;

        public ProfessorUniSubjectsRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override ProfessorUniSubjects Insert(ProfessorUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = _context.ProfessorUniSubjects.Add(entity);
                dbEntity.State = EntityState.Added;
                Save();

                return dbEntity.Entity;
            }
            
        }

        public override async Task<ProfessorUniSubjects> InsertAsync(ProfessorUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = await _context.ProfessorUniSubjects.AddAsync(entity);
                dbEntity.State = EntityState.Added;

                Save();

                return dbEntity.Entity;
            }
            
        }

        public override void Delete(ProfessorUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = _context.ProfessorUniSubjects.Remove(entity);
                dbEntity.State = EntityState.Deleted;
                Save();
            }
            
        }

        public override ProfessorUniSubjects Update(ProfessorUniSubjects entity)
        {
            using (_context)
            {
                var dbEntity = _context.ProfessorUniSubjects.Update(entity);
                dbEntity.State = EntityState.Modified;
                Save();

                return dbEntity.Entity;
            }
            
        }

        public override List<ProfessorUniSubjects> GetAllList(Expression<Func<ProfessorUniSubjects, bool>> predicate)
        {
            using (_context)
            {
                return _context.ProfessorUniSubjects.Where(predicate).ToList();

            }
        }

        public override Task<List<ProfessorUniSubjects>> GetAllListAsync(Expression<Func<ProfessorUniSubjects, bool>> predicate)
        {
            using (_context)
            {
                return _context.ProfessorUniSubjects.Where(predicate).ToListAsync();

            }
        }

        public override IQueryable<ProfessorUniSubjects> GetAll()
        {
            using (_context)
            {
                return _context.ProfessorUniSubjects;

            }
        }

        public override Task<List<ProfessorUniSubjects>> GetAllListAsync()
        {
            using (_context)
            {
                return _context.ProfessorUniSubjects.ToListAsync();

            }
        }

        public override ProfessorUniSubjects Get(Guid ProfessorUniSubjectsId)
        {
            using (_context)
            {
                return _context.ProfessorUniSubjects.Find(ProfessorUniSubjectsId);

            }
        }

        public override Task<ProfessorUniSubjects> GetAsync(Guid ProfessorUniSubjectsId)
        {
            using (_context)
            {
                return _context.ProfessorUniSubjects.FindAsync(ProfessorUniSubjectsId);

            }
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

    }
}
