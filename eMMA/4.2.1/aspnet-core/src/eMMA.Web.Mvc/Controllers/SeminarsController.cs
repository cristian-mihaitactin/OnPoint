using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class SeminarsController : Controller
    {
        private readonly eMMARepositoryBase<SeminarInstance,Guid> _seminarRepository;

        public SeminarsController(eMMARepositoryBase<SeminarInstance, Guid> seminarRepository)
        {
            _seminarRepository = seminarRepository;
        }

        public IActionResult Index()
        {
            var allSeminars = _seminarRepository.GetAll().ToList();
            return View(allSeminars);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(SeminarInstance seminar)
        {
            _seminarRepository.Add(seminar);
            _seminarRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var seminar = _seminarRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(seminar);
        }

        public IActionResult Edit(Guid? id)
        {
            var seminar = _seminarRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(seminar);
        }

        public IActionResult EditSave(SeminarInstance seminar)
        {
            _seminarRepository.Edit(seminar);
            _seminarRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var seminar = _seminarRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _seminarRepository.Delete(seminar);
            _seminarRepository.Save();
            return RedirectToAction("Index");
        }
    }
}