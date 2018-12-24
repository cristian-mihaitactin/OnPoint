using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly IRepository<Professor> _professorRepository;

        public ProfessorsController(IRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public IActionResult Index()
        {
            var allStudents = _professorRepository.GetAll().ToList();
            return View(allStudents);
        }

        public IActionResult Create(Professor professor)
        {
            if (professor.Id != 0)
            {
                professor.Id = 0;
                _professorRepository.Add(professor);
                _professorRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Details(int? id)
        {
            var professor = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(professor);
        }

        public IActionResult Edit(int? id)
        {
            var professor = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(professor);
        }

        public IActionResult Delete(int? id)
        {
            var student = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _professorRepository.Delete(student);
            _professorRepository.Save();
            return RedirectToAction("Index");
        }
    }
}