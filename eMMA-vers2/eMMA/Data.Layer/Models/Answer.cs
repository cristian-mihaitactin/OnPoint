using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Answer
    {
        public Guid StudentId { get; private set; }
        public Guid QuestionId { get; private set; }
        public string AnswerText { get; private set; }

        public Answer()
        {
            //EF needs this
        }
    }
}
