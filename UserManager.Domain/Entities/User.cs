using System;

namespace UserManager.Domain.Entities
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }

        public string Password { get; set; }

        public virtual bool Status { get; set; }
    }
}