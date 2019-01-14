using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.Entities;

namespace eMMA.Web.Models.UniSubjects
{
    public class UniSubjectDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<LaboratoryInstance> Labs { get; set; }
        public ICollection<SeminarInstance> Seminars { get; set; }
        public ICollection<CourseInstance> Courses { get; set; }
    }
}
