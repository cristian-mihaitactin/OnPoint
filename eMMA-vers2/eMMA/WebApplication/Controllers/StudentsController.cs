using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentsController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var allStudents = _studentRepository.GetAll().ToList();
            return View(allStudents);
        }

        public IActionResult Create(Student student)
        {
            if (student.Id != 0)
            {
                student.Id = 0;
                _studentRepository.Add(student);
                _studentRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Details(int? id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _studentRepository.Delete(student);
            _studentRepository.Save();
            return RedirectToAction("Index");
        }
    }
}