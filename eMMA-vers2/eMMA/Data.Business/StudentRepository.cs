using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChangesAsync();
        }

        public Task<Student> GetById(int id)
        {
            return _context.Students.FindAsync(id);
        }

        public IReadOnlyList<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Task<List<Student>> GetAllAsync()
        {
            return _context.Students.ToListAsync();
        }
    }
}
