using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Attendance
    {
        public Guid AttendanceId { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid ObjectId { get; private set; }
        public ObjectType ObjectType { get; private set; }

        public Attendance()
        {
            //EF needs this
        }
    }
}
