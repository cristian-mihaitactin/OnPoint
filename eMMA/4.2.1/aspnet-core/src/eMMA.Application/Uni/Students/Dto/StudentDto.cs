using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using eMMA.Entities;

namespace eMMA.Uni.Students.Dto
{
    [AutoMapFrom(typeof(eMMA.Entities.Student))]
    public class StudentDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }

        public string NrMatricol { get; set; }
        public ICollection<Mark> MarkList { get; private set; }
        public ICollection<Homework> HomeworkList { get; private set; }
        public ICollection<Attendance> AttendanceList { get; private set; }
        public ICollection<StudentUniSubjects> ObjectList { get; set; }


    }
}
