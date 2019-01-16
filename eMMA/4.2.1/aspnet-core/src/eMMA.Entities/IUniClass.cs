using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace eMMA.Entities
{
    public enum UniClassType
    {
        Course,
        Seminar,
        Lab
    }
    public abstract class IUniClass : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AttendenceCode { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public ICollection<Student> AttendingList { get; set; }
        public string Description { get; set; }
        public ICollection<File> FileList { get; set; }
        public ICollection<Question> QuestionList { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ProfId{ get; set; }

        //Added on the fly
        public UniClassType UniClassType { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
