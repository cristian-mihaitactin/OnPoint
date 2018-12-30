using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Mark
    {
        public Guid MarkId { get; private set; }
        public double Value { get; private set; }
        public DateTime Date { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid InstanceId { get; private set; }

        public Mark()
        {
            //EF needs this
        }
    }
}
