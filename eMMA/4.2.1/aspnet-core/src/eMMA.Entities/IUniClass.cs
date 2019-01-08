using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMMA.Entities
{
    public abstract class IUniClass : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public ICollection<Student> AttendingList { get; set; }
        public string Description { get; set; }
        public ICollection<File> FileList { get; set; }
        public ICollection<Question> QuestionList { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
