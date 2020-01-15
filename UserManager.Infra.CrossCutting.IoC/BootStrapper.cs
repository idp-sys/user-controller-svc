using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleInjector;
using UserManager.Application.Interfaces.Services;
using UserManager.Application.Services;
using UserManager.Domain.Interfaces.Repositories;
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
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            container.Register<IUserService, UserService>(Lifestyle.Scoped);
        }
    }
}