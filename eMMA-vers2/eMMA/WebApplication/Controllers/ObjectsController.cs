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
    public class ObjectsController : ControllerBase
    {
        private readonly IRepository<Object> _repository;

        public ObjectsController(IRepository<Object> repository)
        {
            _repository = repository;
        }

        // GET: api/student
        [HttpGet]
        public Task<ActionResult<IEnumerable<Object>>> GetObjects()
        {
            return _repository.GetAll();
        }

        // GET: api/objects/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetObject(int id)
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