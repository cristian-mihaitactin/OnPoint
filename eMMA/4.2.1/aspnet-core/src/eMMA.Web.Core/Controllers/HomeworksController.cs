using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.Controllers;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeworksController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Homework, Guid> _homeworkRepository;

        public HomeworksController(eMMARepositoryBase<Homework, Guid> homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }

        [HttpGet]
        public Homework GetHomework(Guid id)
        {
            var homework = _homeworkRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return homework;
        }

        [HttpPost]
        public void PostHomework(Homework homework)
        {
            _homeworkRepository.Edit(homework);
            _homeworkRepository.Save();
        }

        [HttpPut]
        public void PutHomework(Homework homework)
        {
            _homeworkRepository.Add(homework);
            _homeworkRepository.Save();
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            var homework = _homeworkRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _homeworkRepository.Delete(homework);
            _homeworkRepository.Save();
        }
    }
}