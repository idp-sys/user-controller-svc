using System;
using System.Collections.Generic;
using System.Text;

namespace UserController.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
