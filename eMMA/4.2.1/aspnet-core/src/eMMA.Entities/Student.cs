using System;
using System.Collections.Generic;
using System.Text;

namespace eMMA.Entities
{
    public class Student : User
    {
        public string NrMatricol { get; set; }
        public ICollection<Mark> MarkList { get; private set; }
        public ICollection<Homework> HomeworkList { get; private set; }
        public ICollection<Attendance> AttendanceList { get; private set; }

        public Student()
        {
            //EF needs this
        }

        public Student(Guid guid, string nrMatricol, string username, string password, string firstName, string lastName, string email)
        {
            Id = guid;
            NrMatricol = nrMatricol;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
