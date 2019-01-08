using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{

    public class QuestionsController : Controller
    {
        private readonly eMMARepositoryBase<Question, Guid> _questionRepository;

        public QuestionsController(eMMARepositoryBase<Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public IActionResult Index()
        {
            var allQuestions = _questionRepository.GetAll().ToList();
            return View(allQuestions);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Question question)
        {
            _questionRepository.Add(question);
            _questionRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var question = _questionRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(question);
        }

        public IActionResult Edit(Guid? id)
        {
            var question = _questionRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(question);
        }

        public IActionResult EditSave(Question question)
        {
            _questionRepository.Edit(question);
            _questionRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var question = _questionRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _questionRepository.Delete(question);
            _questionRepository.Save();
            return RedirectToAction("Index");
        }
    }
}