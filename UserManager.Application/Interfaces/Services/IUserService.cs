using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(User user);
        Task<string> UpdateUserAsync(string id, User userData);
        Task<string> DeleteUserAsync(string id, bool status);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByNameAsync(string name);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}