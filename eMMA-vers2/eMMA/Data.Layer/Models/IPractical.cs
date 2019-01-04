using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public abstract class IPractical : IUniClass
    {
        public ICollection<Mark> MarkList { get; set; } //doubt?!?
        public Homework Homework{ get; set; }
    }
}
