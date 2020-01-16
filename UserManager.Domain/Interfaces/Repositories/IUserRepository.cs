using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(User user);
        Task<string> UpdateUserAsync(string id, User userData);
        Task<string> DeleteUserAsync(string id, bool status);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByNameAsync(string name);
        Task<IEnumerable<User>> GetAllUsersAsync();

    }
}