using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly IRepository<Attendance> _attendanceRepository;

        public AttendancesController(IRepository<Attendance> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public IActionResult Index()
        {
            var allAttendances = _attendanceRepository.GetAll().ToList();
            return View(allAttendances);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(Attendance attendance)
        {
            _attendanceRepository.Add(attendance);
            _attendanceRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            var attendance = _attendanceRepository.FindBy(a => a.AttendanceId == id).FirstOrDefault();
            return View(attendance);
        }

        public IActionResult Edit(Guid? id)
        {
            var attendance = _attendanceRepository.FindBy(a => a.AttendanceId == id).FirstOrDefault();
            return View(attendance);
        }

        public IActionResult EditSave(Attendance attendance)
        {
            _attendanceRepository.Edit(attendance);
            _attendanceRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var attendance = _attendanceRepository.FindBy(a => a.AttendanceId == id).FirstOrDefault();
            _attendanceRepository.Delete(attendance);
            _attendanceRepository.Save();
            return RedirectToAction("Index");
        }
    }
}