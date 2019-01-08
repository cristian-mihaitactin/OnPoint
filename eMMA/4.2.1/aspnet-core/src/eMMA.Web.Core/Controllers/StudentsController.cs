using System;
using System.Linq;
using eMMA.Controllers;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentsController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Student, Guid> _studentRepository;

        public StudentsController(eMMARepositoryBase<Student, Guid> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public Student GetStudent(Guid id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return student;
        }

        [HttpPost]
        public void PostStudent(Student student)
        {
            _studentRepository.Edit(student);
            _studentRepository.Save();
        }

        [HttpPut]
        public void PutStudent(Student student)
        {
            _studentRepository.Add(student);
            _studentRepository.Save();
        }

        [HttpDelete]
        public void DeleteStudent(Guid id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _studentRepository.Delete(student);
            _studentRepository.Save();
        }
    }
}