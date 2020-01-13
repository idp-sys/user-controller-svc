using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleInjector;
using UserManager.Domain.Interfaces.Repositories;
using UserManager.Domain.Interfaces.Services;
using UserManager.Infra.CrossCutting.Identity.Config;
using UserManager.Infra.CrossCutting.Identity.Context;
using UserManager.Infra.CrossCutting.Identity.Model;
using UserManager.Infra.Data.Repositories;

namespace UserManager.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ApplicationDbContext>();

            container.Register<IidentityApplicationUserManager, ApplicationUserManager>();

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));

            container.Register<IUserRepository, UserRepository>();
        } 
    }
}