using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UserManager.Domain.Entities;
using UserManager.Infra.CrossCutting.Identity.Config;

namespace UserManager.Infra.CrossCutting.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public bool Status { get; set; }
    }
}