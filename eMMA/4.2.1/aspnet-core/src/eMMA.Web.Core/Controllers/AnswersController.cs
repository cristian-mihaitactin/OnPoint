using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMMA.Entities;
using eMMA.EntityFrameworkCore.Repositories;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AnswersController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Answer, Guid> _answerRepository;

        public AnswersController(eMMARepositoryBase<Answer, Guid> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpGet]
        public Answer GetAnswer(Guid id)
        {
            var question = _answerRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return question;
        }

        [HttpPost]
        public void PostAnswer(Answer answer)
        {
            _answerRepository.Edit(answer);
            _answerRepository.Save();
        }

        [HttpPut]
        public void PutAnswer(Answer answer)
        {
            _answerRepository.Add(answer);
            _answerRepository.Save();
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            var answer = _answerRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _answerRepository.Delete(answer);
            _answerRepository.Save();
        }
    }
}