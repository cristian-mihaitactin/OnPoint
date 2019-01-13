using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eMMA.Entities
{
    public enum ObjectType
    {
        Course,
        Laboratory,
        Seminar
    }

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


        public UniSubject(){}
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
