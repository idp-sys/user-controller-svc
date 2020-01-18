using System;
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
            try
            {
                return await _userRepository.CreateUserAsync(model);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public async Task<string> DeleteUserAsync(string id)
        {
            try
            {
                return await _userRepository.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _userRepository.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            try
            {
                return await _userRepository.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public User GetUserByName(string name)
        {
            try
            {
                return _userRepository.GetUserByName(name);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateUserAsync(string id, User model)
        {
            try
            {
                return await _userRepository.UpdateUserAsync(id, model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}