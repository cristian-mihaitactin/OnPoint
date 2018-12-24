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
    public class UniClassesController : ControllerBase
    {
        private readonly IRepository<UniClass> _repository;

        public UniClassesController(IRepository<UniClass> repository)
        {
            _repository = repository;
        }

        // GET: api/student
        [HttpGet]
        public Task<ActionResult<IEnumerable<UniClass>>> GetUniClasses()
        {
            return _repository.GetAll();
        }

        // GET: api/UniClasss/1
        [HttpGet("{id}")]
        public async Task<ActionResult<UniClass>> GetUniClass(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
            {
                return BadRequest();
            }

            return obj;
        }
    }
}