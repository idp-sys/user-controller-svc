using System;
using System.Collections.Generic;
using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Repository;

namespace Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();


        public T Post<V>(T obj, string databasePath) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj, databasePath);
            return obj;
        }

        public void Put<V>(int id, string databasePath, string name = null, string status = null) where V : AbstractValidator<T>
        {
            var user = repository.Select(id, databasePath);

            if (name != null)
            {
                user.GetType().GetProperty("Name")?.SetValue(user, name);
            }

            if (status != null)
            {
                user.GetType().GetProperty("Status")?.SetValue(user, name);
            }

            Validate(user, Activator.CreateInstance<V>());

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

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não Encontrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
