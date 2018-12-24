using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<UniClass> _uniClassRepository;

        public HomeController(IRepository<UniClass> uniClassRepository)
        {
            _uniClassRepository = uniClassRepository;
        }

        public IActionResult ViewAllStudents()
        {
            var students = _studentRepository.GetAll();
            var studentsViewModel = new StudentsViewModel() { Title = "Yeees", Students = students.ToList() };

            return View(studentsViewModel);
        }
        
        public IActionResult ViewAllUniClasses()
        {
            var uniClasses = _uniClassRepository.GetAll();
            var uniClassesViewModel = new UniClassesViewModel() { Title = "Mate", UniClasses = uniClasses.ToList() };

            return View(uniClassesViewModel);
        }
    }
}