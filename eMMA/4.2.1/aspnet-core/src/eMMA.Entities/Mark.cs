using Abp.Domain.Entities;
using System;

namespace eMMA.Entities
{
    public class Mark : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid StudentId { get; set; }
        public Guid InstanceId { get; set; }

        public Mark()
        {
            //EF needs this
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
