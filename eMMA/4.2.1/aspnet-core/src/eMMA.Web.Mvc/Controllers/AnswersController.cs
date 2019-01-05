using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMMA.Entities;
using eMMA.EntityFrameworkCore.Repositories;

namespace eMMA.Web.Controllers
{
 
    public class AnswersController : Controller
    {
        private readonly eMMARepositoryBase<Answer, Guid> _answerRepository;

        public AnswersController(eMMARepositoryBase<Answer, Guid> answerRepository)
        {
            _answerRepository = answerRepository;
        }


        public IActionResult Index()
        {
            var allAnswers = _answerRepository.GetAll().ToList();
            return View(allAnswers);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Answer answer)
        {
            _answerRepository.Add(answer);
            _answerRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var question = _answerRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(question);
        }

        public IActionResult Edit(Guid? id)
        {
            var question = _answerRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return View(question);
        }

        public IActionResult EditSave(Answer answer)
        {
            _answerRepository.Edit(answer);
            _answerRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var answer = _answerRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _answerRepository.Delete(answer);
            _answerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}