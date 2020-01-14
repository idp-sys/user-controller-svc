using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UserManager.Infra.CrossCutting.Identity.Model;

namespace UserManager.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=UserManager;Integrated Security= true");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}