using System;
using System.Collections.Generic;
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
        
        public int IdSubject { get; private set; }
        public string Title {get; set;}
        public int Credits {get; private set;}
    
        public ICollection<LaboratoryInstance> Labs {get;set;}
        public ICollection<SeminarInstance> Seminars {get;set;}
        public ICollection<CourseInstance> Courses {get;set;}


        public UniSubject(){}
        public UniSubject(int id, string title,int credits)
        {
            IdSubject = id;
            Title = title;
            Credits = credits;
        }
    }
}
