using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AttendancesController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<Attendance, Guid> _attendanceRepository;

        public AttendancesController(eMMARepositoryBase<Attendance, Guid> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet]
        public Attendance GetAttendance(Guid id)
        {
            var attendance = _attendanceRepository.FindBy(a => a.Id == id).FirstOrDefault();
            return attendance;
        }

        [HttpPut]
        public void PutAttendance(Attendance attendance)
        {
            _attendanceRepository.Add(attendance);
            _attendanceRepository.Save();
        }

        [HttpPost]
        public void PostAttendance(Attendance attendance)
        {
            _attendanceRepository.Edit(attendance);
            _attendanceRepository.Save();
        }

        [HttpDelete]
        public void DeleteAttendance(Guid id)
        {
            var attendance = _attendanceRepository.FindBy(a => a.Id == id).FirstOrDefault();
            _attendanceRepository.Delete(attendance);
            _attendanceRepository.Save();
        }
    }
}