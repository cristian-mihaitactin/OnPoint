using Abp.Domain.Entities;
using System;

namespace eMMA.Entities
{
    public class Attendance : IEntity<Guid>
    {
        public Guid StudentId { get; private set; }
        public Guid ObjectId { get; private set; }
        public UniClassType UniClassType { get; private set; }
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
