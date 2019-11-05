using System;
using System.Collections.Generic;
using System.Text;
using UserController.Domain.Entities;

namespace UserController.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post(T obj, string databasePath);

        void Put(int id, string databasePath, string name = null, string status = null);

        void Delete(int id, string databasePath);

        T Get(int id, string databasePath);

        IEnumerable<T> Get(string name, string databasePath);

        IEnumerable<T> Get(string databasePath);
    }
}
