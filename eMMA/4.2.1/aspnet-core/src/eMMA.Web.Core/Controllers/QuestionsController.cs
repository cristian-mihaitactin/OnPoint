using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class QuestionsController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Question, Guid> _questionRepository;

        public QuestionsController(eMMARepositoryBase<Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public Question GetQuestion(Guid id)
        {
            var question = _questionRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return question;
        }

        [HttpPost]
        public void PostQuestion(Question question)
        {
            _questionRepository.Edit(question);
            _questionRepository.Save();
        }

        [HttpPut]
        public void PutQuestion(Question question)
        {
            _questionRepository.Add(question);
            _questionRepository.Save();
        }

        [HttpDelete]
        public void DeleteQuestion(Guid id)
        {
            var question = _questionRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _questionRepository.Delete(question);
            _questionRepository.Save();
        }
    }
}