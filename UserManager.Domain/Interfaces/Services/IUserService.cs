using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(User user);

        Task<string> UpdateUserAsync(string id, User userData);

        Task<string> DeleteUserAsync(string id);

        Task<User> GetUserByIdAsync(string id);

        User GetUserByName(string name);

        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}