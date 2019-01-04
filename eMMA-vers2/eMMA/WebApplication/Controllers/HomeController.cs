using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<UniSubject> _uniSubjectRepository;

        public HomeController(IRepository<UniSubject> uniSubjectRepository)
        {
            _uniSubjectRepository = uniSubjectRepository;
        }

        //public IActionResult ViewAllStudents()
        //{
        //    var students = _studentRepository.GetAll();
        //    var studentsViewModel = new StudentsViewModel() { Title = "Yeees", Students = students.ToList() };

        //    return View(studentsViewModel);
        //}
        
        public IActionResult ViewAllUniClasses()
        {
            var uniSubjects = _uniSubjectRepository.GetAll();
            var uniSubjectsViewModel = new UniSubject { Title = "Mate"};

            return View(uniSubjectsViewModel);
        }
    }
}