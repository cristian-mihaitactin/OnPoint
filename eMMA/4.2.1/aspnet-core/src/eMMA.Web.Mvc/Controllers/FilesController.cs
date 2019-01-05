using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class FilesController : Controller
    {
        private readonly eMMARepositoryBase<File, Guid> _fileRepository;

        public FilesController(eMMARepositoryBase<File, Guid> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public IActionResult Index()
        {
            var allFiles = _fileRepository.GetAll().ToList();
            return View(allFiles);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(File file)
        {
            _fileRepository.Add(file);
            _fileRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var file = _fileRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(file);
        }

        public IActionResult Edit(Guid? id)
        {
            var file = _fileRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(file);
        }

        public IActionResult EditSave(File file)
        {
            _fileRepository.Edit(file);
            _fileRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var file = _fileRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _fileRepository.Delete(file);
            _fileRepository.Save();
            return RedirectToAction("Index");
        }
    }
}