using System;
using Abp.Domain.Entities;

namespace eMMA.Entities
{
    public class ProfessorUniSubjects : IEntity<Guid>
    {
        public bool IsTransient()
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; set; }
        public Guid UniSubjectId { get; set; }
        public Guid ProfessorId { get; set; }

        public UniSubject UniSubject { get; set; }
        public Professor Professor { get; set; }
    }
}
