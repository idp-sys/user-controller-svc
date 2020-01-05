using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj, string databasePath) where V : AbstractValidator<T>;

        void Put<V>(int id, string databasePath, string name = null, string status = null) where V : AbstractValidator<T>;

        void Delete(int id, string databasePath);

        T Get(int id, string databasePath);

        IEnumerable<T> Get(string name, string databasePath);

        IEnumerable<T> Get(string databasePath);
    }
}
