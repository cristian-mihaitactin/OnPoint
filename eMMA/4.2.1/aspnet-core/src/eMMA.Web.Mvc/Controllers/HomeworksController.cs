using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class HomeworksController : Controller
    {
        private readonly eMMARepositoryBase<Homework, Guid> _homeworkRepository;

        public HomeworksController(eMMARepositoryBase<Homework, Guid> homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }

        public IActionResult Index()
        {
            var allHomeworks = _homeworkRepository.GetAll().ToList();
            return View(allHomeworks);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Homework homework)
        {
            _homeworkRepository.Add(homework);
            _homeworkRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var homework = _homeworkRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(homework);
        }

        public IActionResult Edit(Guid? id)
        {
            var homework = _homeworkRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(homework);
        }

        public IActionResult EditSave(Homework homework)
        {
            _homeworkRepository.Edit(homework);
            _homeworkRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var homework = _homeworkRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _homeworkRepository.Delete(homework);
            _homeworkRepository.Save();
            return RedirectToAction("Index");
        }
    }
}