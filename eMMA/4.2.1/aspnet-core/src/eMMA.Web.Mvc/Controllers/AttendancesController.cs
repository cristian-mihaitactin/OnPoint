using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly eMMARepositoryBase<Attendance, Guid> _attendanceRepository;

        public AttendancesController(eMMARepositoryBase<Attendance, Guid> attendanceRepository)
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