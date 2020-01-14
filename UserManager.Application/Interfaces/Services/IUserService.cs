using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Domain.Entities;
using UserManager.Infra.CrossCutting.Identity.Config;
using UserManager.Infra.CrossCutting.Identity.Model;

namespace UserManager.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateUser(User model, ApplicationUserManager userManager);
        public Task<IdentityResult> UpdateUser(User model, ApplicationUserManager userManager);
        public Task<IdentityResult> DeleteUser(User model, ApplicationUserManager userManager);
        public Task<ApplicationUser> GetUserById(User model, ApplicationUserManager userManager);
        public Task<ApplicationUser> GetUserByName(User model, ApplicationUserManager userManager);
        public IQueryable<ApplicationUser> GetAlusers(User model, ApplicationUserManager userManager);

    }
}
