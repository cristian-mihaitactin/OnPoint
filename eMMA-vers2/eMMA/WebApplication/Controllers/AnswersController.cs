using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repositories;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : Controller
    {
        private readonly IRepository<Answer> _answerRepository;

        public AnswersController(IRepository<Answer> answerRepository)
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