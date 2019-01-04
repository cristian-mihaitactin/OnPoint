using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class CourseInstance : IUniClass
    {
        public Guid Id { get; private set; }
     
        public CourseInstance()
        {
            //EF needs this
        }
    }
}
