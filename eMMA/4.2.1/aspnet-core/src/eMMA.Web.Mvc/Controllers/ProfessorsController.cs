using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly eMMARepositoryBase<Professor, Guid> _professorRepository;

        public ProfessorsController(eMMARepositoryBase<Professor, Guid> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public IActionResult Index()
        {
            var allStudents = _professorRepository.GetAll().ToList();
            return View(allStudents);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Professor professor)
        {
            _professorRepository.Add(professor);
            _professorRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var professor = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(professor);
        }

        public IActionResult Edit(Guid? id)
        {
            var professor = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(professor);
        }

        public IActionResult EditSave(Professor professor)
        {
            _professorRepository.Edit(professor);
            _professorRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var student = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _professorRepository.Delete(student);
            _professorRepository.Save();
            return RedirectToAction("Index");
        }
    }
}