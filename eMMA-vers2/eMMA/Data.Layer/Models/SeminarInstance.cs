using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    class SeminarInstance : IObject, IPractical
    {
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<Student> AttendingList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<string> FilePathList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<Question> QuestionList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Mark> MarkList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Homework Homework { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SeminarInstance()
        {
            //EF needs this
        }
    }
}
