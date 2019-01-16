using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MarksController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Mark, Guid> _markRepository;

        public MarksController(eMMARepositoryBase<Mark, Guid> markRepository)
        {
            _markRepository = markRepository;
        }
        
        [HttpGet]
        public Mark GetMark(Guid id)
        {
            var mark = _markRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return mark;
        }

        [HttpPost]
        public void PostMark(Mark mark)
        {
            _markRepository.Edit(mark);
            _markRepository.Save();
        }

        [HttpPut]
        public void PutMark(Mark mark)
        {
            _markRepository.Add(mark);
            _markRepository.Save();
        }

        [HttpDelete]
        public void DeleteMark(Guid id)
        {
            var mark = _markRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _markRepository.Delete(mark);
            _markRepository.Save();
        }
    }
}