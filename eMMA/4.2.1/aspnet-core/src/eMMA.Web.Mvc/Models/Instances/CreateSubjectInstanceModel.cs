using System;
using eMMA.Entities;

namespace eMMA.Web.Models.Instances
{
    public class CreateSubjectInstanceModel
    {
        public string Name { get; set; }
        public string Desciption { get; set; }

        public Guid SubjectId { get; set; }
        public Guid ProfId { get; set; }

        public UniClassType Type { get; set; }
    }
}
