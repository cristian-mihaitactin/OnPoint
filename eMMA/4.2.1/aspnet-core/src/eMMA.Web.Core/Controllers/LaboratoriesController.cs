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
    public class LaboratoriesController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<LaboratoryInstance, Guid> _laboratoryRepository;

        public LaboratoriesController(eMMARepositoryBase<LaboratoryInstance, Guid> laboratoryRepository)
        {
            _laboratoryRepository = laboratoryRepository;
        }

        [HttpGet]
        public LaboratoryInstance GetLaboratory(Guid id)
        {
            var laboratory = _laboratoryRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return laboratory;
        }

        [HttpPost]
        public void PostLaboratory(LaboratoryInstance laboratory)
        {
            _laboratoryRepository.Edit(laboratory);
            _laboratoryRepository.Save();
        }

        [HttpPut]
        public void PutLaboratory(LaboratoryInstance laboratory)
        {
            _laboratoryRepository.Add(laboratory);
            _laboratoryRepository.Save();
        }

        [HttpDelete]
        public void DeleteLaboratory(Guid id)
        {
            var laboratory = _laboratoryRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _laboratoryRepository.Delete(laboratory);
            _laboratoryRepository.Save();
        }
    }
}