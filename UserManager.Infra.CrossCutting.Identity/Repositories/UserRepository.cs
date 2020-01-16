using System;
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
        private readonly ApplicationDbContext _db;

        public UserRepository()
        {
            _db = new ApplicationDbContext();
        }

        public void createUser(User user)
        {
            _db.UserDomain.Add(user);
            var result = _db.SaveChanges();
        }
        public void updateUser(string id , User userData)
        {
          var user  =  _db.UserDomain.Find(id);
            user.UserName = userData.UserName;
            user.Email = userData.Email;
            _db.UserDomain.Update(user);
             var result = _db.SaveChanges();
        }

        public void deleteUser(string id)
        {
            var user = _db.UserDomain.Find(id);
            
            user.LockoutEnabled = false;
           
            _db.UserDomain.Update(user);
            
            var result = _db.SaveChanges();
        }

        public async Task<User> getUserByIdAsync(string id)
        {
            return  await _db.UserDomain.FindAsync(id);
        }

        public async Task<User> getUserByNameAsync(string name)
        {
            return await _db.UserDomain.FindAsync(name);
        }

        public IEnumerable<User> getAllUsers()
        {
            return _db.UserDomain.ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
