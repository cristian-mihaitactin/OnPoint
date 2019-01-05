using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly eMMARepositoryBase<CourseInstance, Guid> _courseRepository;

        public CoursesController(eMMARepositoryBase<CourseInstance, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            var allcourses = _courseRepository.GetAll().ToList();
            return View(allcourses);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(CourseInstance course)
        {
            _courseRepository.Add(course);
            _courseRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var course = _courseRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(course);
        }

        public IActionResult Edit(Guid? id)
        {
            var course = _courseRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return View(course);
        }

        public IActionResult EditSave(CourseInstance course)
        {
            _courseRepository.Edit(course);
            _courseRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var course = _courseRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _courseRepository.Delete(course);
            _courseRepository.Save();
            return RedirectToAction("Index");
        }
    }
}