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
    public class UniSubjectsController : ControllerBase
    {
        private readonly IRepository<UniSubject> _repository;

        public UniSubjectsController(IRepository<UniSubject> repository)
        {
            _repository = repository;
        }

        // GET: api/uniclass
        [HttpGet]
        public ActionResult<IEnumerable<UniSubject>> GetUniSubjects()
        {
            return Ok(_repository.GetAll());
        }

        // GET: api/UniClasss/1
        [HttpGet("{id}")]
        public ActionResult<UniSubject> GetUniSubject(int id)
        {
            var obj = _repository.GetSingle(id);

            if (obj == null)
            {
                return BadRequest();
            }

            return obj;
        }
    }
}