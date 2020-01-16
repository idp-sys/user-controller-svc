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
        //Task<IdentityResult> CreateUser(User model, ApplicationUserManager userManager);


         void CreateUser(User model);
         //Task<IdentityResult> UpdateUser(string id, User model, ApplicationUserManager userManager);

        //Task<IdentityResult> DeleteUser(string id, ApplicationUserManager userManager);

        //Task<ApplicationUser> GetUserById(string id, ApplicationUserManager userManager);

        // Task<ApplicationUser> GetUserByName(string name, ApplicationUserManager userManager);

        //IQueryable<ApplicationUser> GetAllusers(ApplicationUserManager userManager);
    }
}