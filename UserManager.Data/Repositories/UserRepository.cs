using System;
using System.Collections.Generic;
using System.Linq;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces.Repositories;
using UserManager.Infra.Data.Context;

namespace UserManager.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _db;

        public UserRepository()
        {
            _db = new UserContext();
        }
        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}