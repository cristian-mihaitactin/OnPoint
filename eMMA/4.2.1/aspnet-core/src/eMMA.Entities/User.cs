using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMMA.Entities
{
    public abstract class User: IEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
//        public ICollection<Object> ObjectList { get; set; }

        public User()
        {
            //EF Needs This
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
