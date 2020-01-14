using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Domain.Entities
{
   public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }

        public string Password { get; set; }

        public virtual bool LockoutEnabled { get; set; }


    }
}
