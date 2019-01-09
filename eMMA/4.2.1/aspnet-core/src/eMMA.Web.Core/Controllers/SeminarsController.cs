using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.Controllers;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SeminarsController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<SeminarInstance,Guid> _seminarRepository;

        public SeminarsController(eMMARepositoryBase<SeminarInstance, Guid> seminarRepository)
        {
            _seminarRepository = seminarRepository;
        }

        [HttpGet]
        public SeminarInstance GetSeminar(Guid id)
        {
            var seminar = _seminarRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return seminar;
        }

        [HttpPost]
        public void PostSeminar(SeminarInstance seminar)
        {
            _seminarRepository.Edit(seminar);
            _seminarRepository.Save();
        }

        [HttpPut]
        public void PutSeminar(SeminarInstance seminar)
        {
            _seminarRepository.Add(seminar);
            _seminarRepository.Save();
        }

        [HttpDelete]
        public void DeleteSeminar(Guid id)
        {
            var seminar = _seminarRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _seminarRepository.Delete(seminar);
            _seminarRepository.Save();
        }
    }
}