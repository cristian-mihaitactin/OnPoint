using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Attendance
    {
        public Guid StudentId { get; private set; }
        public Guid ObjectId { get; private set; }
        public ObjectType ObjectType { get; private set; }

        public Attendance()
        {
            //EF needs this
        }
    }
}
