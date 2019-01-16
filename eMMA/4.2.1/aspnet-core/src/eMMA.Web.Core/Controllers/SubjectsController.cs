using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SubjectsController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<UniSubject, Guid> _repository;

        public SubjectsController(eMMARepositoryBase<UniSubject, Guid> repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public UniSubject GetSubject(Guid id)
        {
            var subject = _repository.FindBy(s => s.Id == id).FirstOrDefault();
            return subject;
        }

        [HttpPost]
        public void PostSubject(UniSubject subject)
        {
            _repository.Edit(subject);
            _repository.Save();
        }

        [HttpPut]
        public void PutSubject(UniSubject subject)
        {
            _repository.Add(subject);
            _repository.Save();
        }

        [HttpDelete]
        public void DeleteSubject(Guid id)
        {
            var subject = _repository.FindBy(s => s.Id == id).FirstOrDefault();
            _repository.Delete(subject);
            _repository.Save();
        }
    }
}