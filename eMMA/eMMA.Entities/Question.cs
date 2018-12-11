using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; private set; }
        public ICollection<Answer> AnswerList { get; private set; }

        public Question()
        {
            //EF needs this
        }
    }
}
