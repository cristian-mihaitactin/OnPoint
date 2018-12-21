using System;
using System.Collections.Generic;

namespace DataLayer
{
    public abstract class User
    {
        public int Id { get; set; }
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
    }
}
