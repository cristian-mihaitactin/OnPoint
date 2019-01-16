using System.Collections.Generic;

namespace eMMA.Entities
{
    public abstract class IPractical : IUniClass
    {
        public ICollection<Mark> MarkList { get; set; } //doubt?!?
        public Homework Homework{ get; set; }
    }
}
