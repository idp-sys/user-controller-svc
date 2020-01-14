using Microsoft.AspNetCore.Identity;
using System;
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

        public async Task<IdentityResult> DeleteUser(User model, ApplicationUserManager userManager)
        {
            IdentityResult result = new IdentityResult();

            var userFound = await userManager.FindByIdAsync(model.Id);
           
            if (userFound != null)
            {
                userFound.LockoutEnabled = true;

                result  = await userManager.UpdateAsync(userFound);
                
                return result;
            }
            return result;
        }

        public async IQueryable<ApplicationUser> GetAlusers( ApplicationUserManager userManager)
        {
            return userManager.Users.ToList();
        }

        public async Task<ApplicationUser> GetUserById(User model, ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserByName(User model, ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateUser(User model, ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }
    }
}
