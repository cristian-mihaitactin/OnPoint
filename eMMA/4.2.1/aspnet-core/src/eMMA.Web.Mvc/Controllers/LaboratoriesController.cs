using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class LaboratoriesController : Controller
    {
        private readonly eMMARepositoryBase<LaboratoryInstance, Guid> _laboratoryRepository;

        public LaboratoriesController(eMMARepositoryBase<LaboratoryInstance, Guid> laboratoryRepository)
        {
            _laboratoryRepository = laboratoryRepository;
        }

        public IActionResult Index()
        {
            var allLaboratories = _laboratoryRepository.GetAll().ToList();
            return View(allLaboratories);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(LaboratoryInstance laboratory)
        {
            _laboratoryRepository.Add(laboratory);
            _laboratoryRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var laboratory = _laboratoryRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(laboratory);
        }

        public IActionResult Edit(Guid? id)
        {
            var laboratory = _laboratoryRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(laboratory);
        }

        public IActionResult EditSave(LaboratoryInstance laboratory)
        {
            _laboratoryRepository.Edit(laboratory);
            _laboratoryRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var laboratory = _laboratoryRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _laboratoryRepository.Delete(laboratory);
            _laboratoryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}