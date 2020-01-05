using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj, string databasePath);

        void Update(int id, string databasePath, string name = null, string status = null);

        void Remove(int id, string databasePath);

        T Select(int id, string databasePath);

        IEnumerable<T> Select(string name, string databasePath);

        IEnumerable<T> SelectAll(string databasePath);
    }
}
