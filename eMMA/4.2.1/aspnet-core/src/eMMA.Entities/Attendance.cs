using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMMA.Entities
{
    public class Attendance : IEntity<Guid>
    {
        public Guid AttendanceId { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid ObjectId { get; private set; }
        public ObjectType ObjectType { get; private set; }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Attendance()
        {
            //EF needs this
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
