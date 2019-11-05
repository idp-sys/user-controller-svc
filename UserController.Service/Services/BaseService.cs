using System;
using System.Collections.Generic;
using System.Text;
using UserController.Domain.Entities;
using UserController.Domain.Interfaces;
using UserController.Infra.Data.Repository;

namespace UserController.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();


        public T Post(T obj, string databasePath)
        {
            repository.Insert(obj, databasePath);
            return obj;
        }

        public void Put(int id, string databasePath, string name = null, string status = null)
        {
            repository.Update(id, databasePath, name, status);
        }

        public void Delete(int id, string databasePath)
        {
            repository.Remove(id, databasePath);
        }

        public T Get(int id, string databasePath)
        {
            return repository.Select(id, databasePath);
        }

        public IEnumerable<T> Get(string name, string databasePath)
        {
            return repository.Select(name, databasePath);
        }

        public IEnumerable<T> Get(string databasePath) => repository.SelectAll(databasePath);
    }
}
