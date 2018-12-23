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
    public class AnswersController : ControllerBase
    {
        private readonly IRepository<Answer> _repository;

        public AnswersController(IRepository<Answer> repository)
        {
            _repository = repository;
        }

        // GET: api/student
        [HttpGet]
        public Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {
            return _repository.GetAll();
        }

        // GET: api/objects/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            var answer = await _repository.GetById(id);

            if (answer == null)
            {
                return BadRequest();
            }

            return answer;
        }
    }
}