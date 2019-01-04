using System;
using System.Linq;
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Student student)
        {
            _studentRepository.Add(student);
            _studentRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(student);
        }

        public IActionResult Edit(Guid? id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(student);
        }

        public IActionResult EditSave(Student student)
        {
//            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _studentRepository.Edit(student);
            _studentRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var student = _studentRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _studentRepository.Delete(student);
            _studentRepository.Save();
            return RedirectToAction("Index");
        }
    }
}