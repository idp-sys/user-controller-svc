using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces.Repositories;
using UserManager.Domain.Interfaces.Services;

namespace UserManager.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUserAsync(User model)
        {
            return await _userRepository.CreateUserAsync(model);
        }

        public async Task<string> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public User GetUserByName(string name)
        {
            return  _userRepository.GetUserByName(name);
        }

        public async Task<string> UpdateUserAsync(string id, User model)
        {
            return await _userRepository.UpdateUserAsync(id, model);
        }
    }
}