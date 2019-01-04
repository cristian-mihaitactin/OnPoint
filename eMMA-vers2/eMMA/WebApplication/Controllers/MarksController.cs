using System;
using System.Linq;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class MarksController : Controller
    {
        private readonly IRepository<Mark> _markRepository;

        public MarksController(IRepository<Mark> markRepository)
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
            var mark = _markRepository.FindBy(m => m.MarkId == id).FirstOrDefault();
            return View(mark);
        }

        public IActionResult Edit(Guid? id)
        {
            var mark = _markRepository.FindBy(m => m.MarkId == id).FirstOrDefault();
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
            var mark = _markRepository.FindBy(m => m.MarkId == id).FirstOrDefault();
            _markRepository.Delete(mark);
            _markRepository.Save();
            return RedirectToAction("Index");
        }
    }
}