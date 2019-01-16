using Abp.Domain.Entities;
using System;

namespace eMMA.Entities
{
    public class Homework : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid InstanceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Homework()
        {
            
            //EF needs this
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
