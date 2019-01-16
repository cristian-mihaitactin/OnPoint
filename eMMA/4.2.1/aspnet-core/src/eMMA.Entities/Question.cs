using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace eMMA.Entities
{
    public class Question : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public ICollection<Answer> AnswerList { get; private set; }

        public Question()
        {
            //EF needs this
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
