using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Homework
    {
        public Guid HomeworkId { get; private set; }
        public Guid InstanceId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Homework()
        {
            
            //EF needs this
        }
    }
}
