using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces.Repositories
{
    //TODO: AJUSTAR CLASSE
    public interface IUserRepository
    {
         void createUser(User user);
          void updateUser(string id, User userData);
          void deleteUser(string id);
          Task<User> getUserByIdAsync(string id);
          Task<User> getUserByNameAsync(string name);
          IEnumerable<User> getAllUsers();

    }
}