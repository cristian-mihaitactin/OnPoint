using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repositories
{
    public class HomeworkRepository : IRepository<Homework>
    {
        private readonly DataLayer.AppContext _context;

        public HomeworkRepository(DataLayer.AppContext context)
        {
            _context = context;
        }

        public void Add(Homework entity)
        {
            _context.Homeworks.Add(entity);
        }

        public void Delete(Homework entity)
        {
            _context.Homeworks.Remove(entity);
        }

        public void Edit(Homework entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Homework> FindBy(Expression<Func<Homework, bool>> predicate)
        {
            return _context.Homeworks.Where(predicate);
        }

        public IQueryable<Homework> GetAll()
        {
            return _context.Homeworks;
        }

        public Homework GetSingle(int personId)
        {
            return _context.Homeworks.Find(personId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
