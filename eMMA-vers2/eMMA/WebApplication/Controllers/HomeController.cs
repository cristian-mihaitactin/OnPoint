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

        public HomeController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult ViewAllStudents()
        {
            var students = _studentRepository.GetAll();
            var studentsViewModel = new StudentsViewModel() { Title = "Yeees", Students = students.ToList() };

            return View(studentsViewModel);
        }
    }
}