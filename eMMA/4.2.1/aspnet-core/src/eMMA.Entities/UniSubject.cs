using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMMA.Entities
{

    public class UniSubject : IEntity<Guid>
    {
        [Column("Id")]
        public Guid Id { get; set; }
        public string Title {get; set;}
        public int Credits {get; set;}
        public string Description { get; set; }

        public ICollection<LaboratoryInstance> Labs {get;set;}
        public ICollection<SeminarInstance> Seminars {get;set;}
        public ICollection<CourseInstance> Courses {get;set;}

        public ICollection<StudentUniSubjects> Students { get; set; }
        public ICollection<ProfessorUniSubjects> Professors { get; set; }

        public UniSubject()
        {
            Labs = new List<LaboratoryInstance>();
            Seminars = new List<SeminarInstance>();
            Courses = new List<CourseInstance>();
            Students = new List<StudentUniSubjects>();
            Professors = new List<ProfessorUniSubjects>();

        }
        public UniSubject(string title,int credits)
        {
            Id = new Guid();
            Title = title;
            Credits = credits;
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
