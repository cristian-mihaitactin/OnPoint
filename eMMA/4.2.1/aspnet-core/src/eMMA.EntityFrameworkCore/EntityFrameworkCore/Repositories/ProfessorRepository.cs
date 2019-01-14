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
    public class ProfessorRepository : eMMARepositoryBase<Professor, Guid>
    {
        private readonly eMMADbContext _context;

        public ProfessorRepository(IDbContextProvider<eMMADbContext> context) : base(context)
        {
            _context = context.GetDbContext();
        }

        public override Professor Insert(Professor entity)
        {
            using (_context)
            {
                var dbEntity = _context.Professors.Add(entity);
                dbEntity.State = EntityState.Added;
                Save();

                return dbEntity.Entity;
            }
            
        }

        public override async Task<Professor> InsertAsync(Professor entity)
        {
            using (_context)
            {
                var dbEntity = await _context.Professors.AddAsync(entity);
                dbEntity.State = EntityState.Added;

                Save();

                return dbEntity.Entity;
            }
            
        }

        public override void Delete(Professor entity)
        {
            using (_context)
            {
                var dbEntity = _context.Professors.Remove(entity);
                dbEntity.State = EntityState.Deleted;
                Save();
            }
            
        }

        public override Professor Update(Professor entity)
        {
            using (_context)
            {
                var dbEntity = _context.Professors.Update(entity);
                dbEntity.State = EntityState.Modified;
                Save();

                var presentSubj = _context.ProfessorUniSubjects.Where(x => x.ProfessorId == entity.Id).OrderBy(s => s.UniSubjectId).ToList();

                //Add
                //if (entity.ObjectList.Count > 0)
                //{
                //    //add all
                //    if (presentSubj.Count == 0)
                //    {
                //        foreach (var professorUniSubjectse in entity.ObjectList)
                //        {
                //            _context.ProfessorUniSubjects.Add(professorUniSubjectse);
                //        }
                //    }
                //    else
                //    {
                //        foreach (var professorUniSubjectse in entity.ObjectList)
                //        {
                //            if (presentSubj.SingleOrDefault(s => s.UniSubjectId == professorUniSubjectse.UniSubjectId) == null)
                //            {
                //                _context.ProfessorUniSubjects.Add(professorUniSubjectse);
                //            }
                //        }
                //    }

                //}

                ////Remove
                //foreach (var professorUniSubjectse in presentSubj)
                //{
                //    if (entity.ObjectList.SingleOrDefault(s => s.UniSubjectId == professorUniSubjectse.UniSubjectId) == null)
                //    {
                //        _context.ProfessorUniSubjects.Remove(professorUniSubjectse);
                //    }
                //}
                Save();

                return dbEntity.Entity;
            }
        }

        public override List<Professor> GetAllList(Expression<Func<Professor, bool>> predicate)
        {
            using (_context)
            {
                return _context.Professors.Where(predicate).ToList();

            }
        }

        public override Task<List<Professor>> GetAllListAsync(Expression<Func<Professor, bool>> predicate)
        {
            using (_context)
            {
                return _context.Professors.Where(predicate).ToListAsync();

            }
        }

        public override IQueryable<Professor> GetAll()
        {
            using (_context)
            {
                return _context.Professors;

            }
        }

        public override Task<List<Professor>> GetAllListAsync()
        {
            using (_context)
            {
                return _context.Professors.ToListAsync();

            }
        }

        public override Professor Get(Guid profesorId)
        {
            using (_context)
            {
                return _context.Professors.Find(profesorId);

            }
        }

        public override Task<Professor> GetAsync(Guid profesorId)
        {
            using (_context)
            {
                return _context.Professors.FindAsync(profesorId);

            }
        }

        public override void Save()
        {
            using (_context)
            {
                _context.SaveChanges();

            }
        }
    }
}
