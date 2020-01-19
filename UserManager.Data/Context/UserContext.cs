using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Entities;
using UserManager.Infra.Data.Config;

namespace UserManager.Infra.Data.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=UserManager;Integrated Security= true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}