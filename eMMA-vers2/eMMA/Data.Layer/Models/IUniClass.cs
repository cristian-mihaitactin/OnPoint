using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public abstract class IUniClass
    {
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public ICollection<Student> AttendingList { get; set; }
        public string Description { get; set; }
        public ICollection<File> FileList { get; set; }
        public ICollection<Question> QuestionList { get; set; }
    }
}
