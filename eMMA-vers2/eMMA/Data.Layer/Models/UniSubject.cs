using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public enum ObjectType
    {
        Course,
        Laboratory,
        Seminar
    }

    public class UniSubject
    {
        [Column("Id")]
        public Guid Id { get; set; }
        public string Title {get; set;}
        public int Credits {get; private set;}
    
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
    }
}
