using System;
using System.Collections.Generic;

namespace eMMA.Web.Models.UniSubjects
{
    public class UniSubjectListViewModel
    {
        public IReadOnlyList<UniSubjectListEntityViewModel> UniSubjects { get; set; }
    }

    public class UniSubjectListEntityViewModel 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int LabsCount { get; set; }
        public int SeminarCount { get; set; }
        public int CourseCount { get; set; }
    }
}
