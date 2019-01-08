using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly eMMARepositoryBase<UniSubject, Guid> _repository;

        public SubjectsController(eMMARepositoryBase<UniSubject, Guid> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var allSubjects = _repository.GetAll().ToList();
            return View(allSubjects);
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        public IActionResult CreateSave(UniSubject subject)
        {
            _repository.Add(subject);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var subject = _repository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(subject);
        }

        public IActionResult Edit(Guid? id)
        {
            var subject = _repository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(subject);
        }

        public IActionResult EditSave(UniSubject subject)
        {
            _repository.Edit(subject);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var subject = _repository.FindBy(s => s.Id == id).FirstOrDefault();
            _repository.Delete(subject);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}