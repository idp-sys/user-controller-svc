using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace UserManager.Infra.CrossCutting.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {

        //public async Task<IdentityResult> CreateUserAsync(UserManager<ApplicationUser> manager , ApplicationUser user)
        //{
        //    var userIdentityResult = await manager.CreateAsync(user);

        //    return userIdentityResult;
        //}

    }
}