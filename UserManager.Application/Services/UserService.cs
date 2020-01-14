using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Application.Interfaces.Services;
using UserManager.Domain.Entities;
using UserManager.Infra.CrossCutting.Identity.Config;
using UserManager.Infra.CrossCutting.Identity.Model;

namespace UserManager.Application.Services
{
    public class UserService : IUserService
    {
        public async Task<IdentityResult> CreateUser(User model, ApplicationUserManager userManager)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<IdentityResult> DeleteUser(string id, ApplicationUserManager userManager)
        {
            IdentityResult result = new IdentityResult();

            var userFound = await userManager.FindByIdAsync(id);

            if (userFound != null)
            {
                userFound.LockoutEnabled = true;

                result = await userManager.UpdateAsync(userFound);

                return result;
            }
            return result;
        }

        public IQueryable<ApplicationUser> GetAllusers(ApplicationUserManager userManager)
        {
            return userManager.Users;
        }

        public async Task<ApplicationUser> GetUserById(string id, ApplicationUserManager userManager)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> GetUserByName(string name, ApplicationUserManager userManager)
        {
            return await userManager.FindByNameAsync(name);
        }

        public async Task<IdentityResult> UpdateUser(string id, User model, ApplicationUserManager userManager)
        {
            IdentityResult result = new IdentityResult();

            var userFound = await userManager.FindByIdAsync(id);

            if (userFound != null)
            {
                userFound.UserName = model.UserName;
                userFound.Email = model.Email;
                userFound.LockoutEnabled = model.LockoutEnabled;

                result = await userManager.UpdateAsync(userFound);

                return result;
            }

            return result;
        }
    }
}