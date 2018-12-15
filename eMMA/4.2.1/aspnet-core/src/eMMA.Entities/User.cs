using System;
using System.Collections.Generic;

namespace DataLayer
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public ICollection<Object> ObjectList { get; private set; }

        public User()
        {
            //EF Needs This
        }
    }
}
