using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UserManager.Domain.Entities;
using UserManager.Infra.CrossCutting.Identity.Config;
using UserManager.Infra.CrossCutting.Identity.Model;

namespace UserManager.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public virtual DbSet<User> UserDomain { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=UserManager;Integrated Security= true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());

            //Obs.para mapear  as outras entities do identity seria necessario
            //criar u arquivo de config para cada uma.
            //como eu estou usando apenas o user estou ignorando a criação do restante
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            //modelBuilder.Ignore<IdentityUser<string>>();
            //modelBuilder.Ignore<ApplicationUser>();
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext();
        }
    }
}