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

    public class UniClass : IUniClass
    {
        public int Id {private set; get;}
        public string Title {get; set;}
        public int Credits {get; private set;}
        //public ICollection<LaboratoryInstance> Labs {get;set;}
        //public ICollection<SeminarInstance> Seminars {get;set;}
        //public ICollection<CourseInstance> Courses {get;set;}
        

        public UniClass(){}
        public UniClass(int id, string title,int credits)
        {
            Id = id;
            Title = title;
            Credits = credits;
        }
    }
}
