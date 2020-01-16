using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces.Repositories;
using UserManager.Infra.CrossCutting.Identity.Context;

namespace UserManager.Infra.CrossCutting.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<string> CreateUserAsync(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                user.Status = true;
                await context.UserDomain.AddAsync(user);
                var result = context.SaveChangesAsync(true).Result;
                return result == 1 ? "User has been created successfully" : "Unable to create";
            }
        }

        public async Task<string> UpdateUserAsync(string id, User userData)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = await context.UserDomain.FindAsync(id);

                if (user != null)
                {
                    user.UserName = userData.UserName;
                    user.Email = userData.Email;

                    context.UserDomain.Update(user);
                    var validator = context.SaveChangesAsync(true).Result;
                    return validator == 1 ? "User has been updated successfully" : "Unable to update";
                }
                else
                {
                    return "User not found";
                }
            }
        }

        public async Task<string> DeleteUserAsync(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = await context.UserDomain.FindAsync(id);

                if (user != null)
                {
                    user.Status = false;
                    context.UserDomain.Update(user);
                    var validator = context.SaveChangesAsync(true).Result;
                    return validator == 1 ? "User has been deleted successfully" : "Unable to delete";
                }
                else
                {
                    return "User not found";
                }
            }
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                return await context.UserDomain.FindAsync(id);
            }
        }

        public User GetUserByName(string name)
        {
            using (var context = new ApplicationDbContext())
            {

                IQueryable<User> myUsers = from user in context.UserDomain
                                           where user.UserName == name
                                           select user;


                return myUsers.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (var context = new ApplicationDbContext())
            {
                return await context.UserDomain.ToAsyncEnumerable().ToList();
            }
        }
    }
}