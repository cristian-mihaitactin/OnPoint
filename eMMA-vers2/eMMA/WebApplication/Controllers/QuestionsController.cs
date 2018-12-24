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
    public class QuestionsController : ControllerBase
    {
        private readonly IRepository<Question> _repository;

        public QuestionsController(IRepository<Question> repository)
        {
            _repository = repository;
        }

        // GET: api/question
        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetQuestions()
        {
            return Ok(_repository.GetAll());
        }

        // GET: api/questions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = _repository.GetSingle(id);

            if (question == null)
            {
                return BadRequest();
            }

            return question;
        }
    }
}