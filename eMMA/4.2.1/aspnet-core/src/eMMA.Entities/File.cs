using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
