using DanielSanchesUserController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielSanchesUserController.Repository
{
    interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Get(string name);
        User Add(User item);
        bool Update(User item);
        void Remove(int id);
    }
}
