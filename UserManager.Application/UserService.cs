using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces.Services;
using UserManager.Infra.Data.Context;

namespace UserManager.Application
{
    public class UserService : IUserService
    {
   
        private readonly UserContext _db;

        public UserService()
        {
            _db = new UserContext();
        }


        //public User CreateUser(User model)
        //{
        //    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //    var result = await _userManager.CreateAsync(user, model.Password);

        //}

        

    }
}
