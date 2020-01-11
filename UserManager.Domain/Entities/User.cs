using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Domain.Entities
{
   public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

    }
}
