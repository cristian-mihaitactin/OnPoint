using Abp.Domain.Entities;
using System;

namespace eMMA.Entities
{
    public class Answer : IEntity<Guid>
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid QuestionId { get; private set; }
        public string AnswerText { get; private set; }
        Guid IEntity<Guid>.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Answer()
        {
            //EF needs this
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
