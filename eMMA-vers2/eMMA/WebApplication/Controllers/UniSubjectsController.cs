using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniSubjectsController : ControllerBase
    {
        //private readonly IRepository<UniSubject> _repository;

        //public UniSubjectsController(IRepository<UniSubject> repository)
        //{
        //    _repository = repository;
        //}

        //public ActionResult Index()
        //{
        //    var allSubjects = _repository.GetAll().ToList();
        //    return View(allSubjects);
        //}

        //public ActionResult Create(int id)
        //{
        //    return View();
        //}

        //public IActionResult CreateSave(UniSubject subject)
        //{
        //    _repository.Add(subject);
        //    _repository.Save();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Details(Guid? id)
        //{
        //    var subject = _repository.FindBy(s => s.IdSubject == id).FirstOrDefault();
        //    return View(subject);
        //}

        //public IActionResult Edit(Guid? id)
        //{
        //    var subject = _repository.FindBy(s => s.IdSubject == id).FirstOrDefault();
        //    return View(subject);
        //}

        //public IActionResult EditSave(UniSubject subject)
        //{
        //    _repository.Edit(subject);
        //    _repository.Save();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(Guid? id)
        //{
        //    var subject = _repository.FindBy(s => s.IdSubject == id).FirstOrDefault();
        //    _repository.Delete(subject);
        //    _repository.Save();
        //    return RedirectToAction("Index");
        //}
    }
}