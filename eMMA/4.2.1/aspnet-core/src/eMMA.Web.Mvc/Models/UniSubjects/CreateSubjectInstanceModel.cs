using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMMA.Web.Models.UniSubjects
{
    public class CreateSubjectInstanceModel
    {
        public string Name { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ProfId { get; set; }

        public InstanceType Type { get; set; }
    }

    public enum InstanceType
    {
        Course,
        Seminar,
        Lab
    }
}
