using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProfessorsController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Professor, Guid> _professorRepository;

        public ProfessorsController(eMMARepositoryBase<Professor, Guid> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public Professor GetProfessor(Guid id)
        {
            var professor = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            return professor;
        }

        [HttpPost]
        public void PostProfessor(Professor professor)
        {
            _professorRepository.Edit(professor);
            _professorRepository.Save();
        }

        [HttpPut]
        public void PutProfessor(Professor professor)
        {
            _professorRepository.Add(professor);
            _professorRepository.Save();
        }

        [HttpDelete]
        public void DeleteProfessor(Guid id)
        {
            var student = _professorRepository.FindBy(s => s.Id == id).FirstOrDefault();
            _professorRepository.Delete(student);
            _professorRepository.Save();
        }
    }
}