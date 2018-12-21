using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IPractical
    {
        ICollection<Mark> MarkList { get; set; } //doubt?!?
        Homework Homework{ get; set; }
    }
}
