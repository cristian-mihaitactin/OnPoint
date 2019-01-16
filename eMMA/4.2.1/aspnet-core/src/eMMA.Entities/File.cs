using Abp.Domain.Entities;
using System;

namespace eMMA.Entities
{
    public class File : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public String Path { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
