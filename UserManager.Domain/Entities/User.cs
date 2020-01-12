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

        //Status
        public virtual bool LockoutEnabled { get; set; }

        //public bool Status { get; set; }

    }
}
