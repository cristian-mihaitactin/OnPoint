using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public ICollection<Answer> AnswerList { get; private set; }

        public Question()
        {
            //EF needs this
        }
    }
}
