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

    public class Object : IObject
    {
        public Guid Id {private set; get;}
        public string Title {get; set;}
        public int Credits {get; private set;}
        public ICollection<LaboratoryInstance> Labs {get;set;}
        public ICollection<SeminarInstance> Seminars {get;set;}
        public ICollection<CourseInstance> Courses {get;set;}
        public Object(){}      

    }
}
