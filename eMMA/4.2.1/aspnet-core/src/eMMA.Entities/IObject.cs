using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IObject
    {
        DateTime Date { get; set; }
        int Number { get; set; }
        ICollection<Student> AttendingList { get; set; }
        string Description { get; set; }
        ICollection<string> FilePathList { get; set; }
        ICollection<Question> QuestionList { get; set; }
    }
}
