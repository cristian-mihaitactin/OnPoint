using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class MarksController : Controller
    {
        private readonly eMMARepositoryBase<Mark, Guid> _markRepository;

        public MarksController(eMMARepositoryBase<Mark, Guid> markRepository)
        {
            _markRepository = markRepository;
        }

        public IActionResult Index()
        {
            var allMarks = _markRepository.GetAll().ToList();
            return View(allMarks);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Mark mark)
        {
            _markRepository.Add(mark);
            _markRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var mark = _markRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(mark);
        }

        public IActionResult Edit(Guid? id)
        {
            var mark = _markRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(mark);
        }

        public IActionResult EditSave(Mark mark)
        {
            _markRepository.Edit(mark);
            _markRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var mark = _markRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _markRepository.Delete(mark);
            _markRepository.Save();
            return RedirectToAction("Index");
        }
    }
}