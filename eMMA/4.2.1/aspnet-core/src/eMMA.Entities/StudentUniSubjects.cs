using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace eMMA.Entities
{
    public class StudentUniSubjects : IEntity<Guid>
    {
        public Guid UniSubjectId { get; set; }
        public Guid StudentId { get; set; }

        public UniSubject UniSubject { get; set; }
        public Student Student { get; set; }
        public bool IsTransient()
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; set; }
    }
}
