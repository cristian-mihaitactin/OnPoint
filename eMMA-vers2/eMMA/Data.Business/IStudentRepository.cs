using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public interface IStudentRepository
    {
        void Create(Student student);
        Task<Student> GetById(int id);
        IReadOnlyList<Student> GetAll();
        Task<List<Student>> GetAllAsync();
    }
}
