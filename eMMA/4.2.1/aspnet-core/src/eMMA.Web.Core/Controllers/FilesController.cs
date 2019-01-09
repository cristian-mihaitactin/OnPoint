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
    public class FilesController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<File, Guid> _fileRepository;

        public FilesController(eMMARepositoryBase<File, Guid> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        public File GetFile(Guid id)
        {
            var file = _fileRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return file;
        }

        [HttpPost]
        public void PostFile(File file)
        {
            _fileRepository.Edit(file);
            _fileRepository.Save();
        }

        [HttpPut]
        public void PutFile(File file)
        {
            _fileRepository.Add(file);
            _fileRepository.Save();
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            var file = _fileRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _fileRepository.Delete(file);
            _fileRepository.Save();
        }
    }
}