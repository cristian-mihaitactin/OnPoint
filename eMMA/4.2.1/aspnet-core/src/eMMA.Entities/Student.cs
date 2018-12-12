using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Student
    {
        public string NrMatricol { get; private set; }
        public ICollection<Mark> MarkList { get; private set; }
        public ICollection<Homework> HomeworkList { get; private set; }
        public ICollection<Attendance> AttendanceList { get; private set; }

        public Student()
        {
            //EF needs this
        }
    }
}
