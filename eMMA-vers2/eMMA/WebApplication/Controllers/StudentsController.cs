using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;

            if (_repository.GetAll().Count() == 0)
            {
                // Create a new Student if collection is empty.
                _repository.Create(new Student(1, "2", "popescu.ion", "pass", "Ion", "Popescu", "popescu@mail.com"));
            }
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _repository.GetById(id);

            if (student == null)
            {
                return BadRequest();
            }

            return student;
        }

//        // POST: api/Todo
//        [HttpPost]
//        public async Task<ActionResult<Student>> PostStudent(Student student)
//        {
//            _repository.Create(student);
//
//            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
//        }
    }
}