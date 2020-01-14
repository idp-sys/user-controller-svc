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

        public Task<IdentityResult> UpdateUser(string id, User model, ApplicationUserManager userManager);

        public Task<IdentityResult> DeleteUser(string id, ApplicationUserManager userManager);

        public Task<ApplicationUser> GetUserById(string id, ApplicationUserManager userManager);

        public Task<ApplicationUser> GetUserByName(string name, ApplicationUserManager userManager);

        public IQueryable<ApplicationUser> GetAllusers(ApplicationUserManager userManager);
    }
}