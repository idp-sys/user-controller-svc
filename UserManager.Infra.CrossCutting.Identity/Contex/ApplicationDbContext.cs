using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using UserManager.Infra.CrossCutting.Identity.Model;

namespace UserManager.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>, IDisposable , IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=UserManager;Integrated Security= true");
        }
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext();
        }
    
    }
}