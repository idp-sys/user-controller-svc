using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Serialization;
using LiteDB;
using UserController.Domain.Entities;
using UserController.Domain.Interfaces;

namespace UserController.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public void Insert(T obj, string databasePath)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var users = db.GetCollection<T>("users");
                users.Insert(obj);

            }
        }

        public void Update(int id, string databasePath, string name = null, string status = null)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var users = db.GetCollection<T>("users");
                var user = (User)(object) users.Find(u => u.Id == id).FirstOrDefault();

                if (user == null) return;

                if (name != null)
                    user.Name = name;

                if (status != null)
                    user.Status = status;

                users.Update((T)(object) user);
            }
        }

        public void Remove(int id, string databasePath)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var users = db.GetCollection<T>("users");
                users.Delete(id);
            }
        }

        public T Select(int id, string databasePath)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var users = db.GetCollection<T>("users");
                return users.Find(u => u.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<T> Select(string name, string databasePath)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var users = db.GetCollection<T>("users");
                return users.Find(u => u.GetType().GetProperty("Name").GetValue(u).ToString().ToLowerInvariant() == name.ToLowerInvariant());
            }
        }

        public IEnumerable<T> SelectAll(string databasePath)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var users = db.GetCollection<T>("users");
                return users.FindAll();
            }
        }
    }
}
