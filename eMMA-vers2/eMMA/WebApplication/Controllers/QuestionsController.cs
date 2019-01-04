using System;
using System.Linq;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{

    public class QuestionsController : Controller
    {
        private readonly IRepository<Question> _questionRepository;

        public QuestionsController(IRepository<Question> questionRepository)
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