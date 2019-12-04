using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DanielSanchesUserController.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DanielSanchesUserController.Repository
{
    public class UserRepository : IUserRepository
    {

        private string fileDir = AppDomain.CurrentDomain.BaseDirectory + "\\usersList.json";
        private List<User> users = new List<User>();
        private int _nextId = 1;        

        public UserRepository()
        {
            
            if (!File.Exists(fileDir))
                SaveJson();

            string output;
            using(StreamReader r = new StreamReader(fileDir))
            {
                output = r.ReadToEnd();
            }            

            users = JsonConvert.DeserializeObject<List<User>>(output);
            if (users.Count > 0)
                _nextId = users[users.Count - 1].Id + 1;

        }

        public User Add(User item)
        {
            if (item == null)
                throw new ArgumentException("item");

            item.Id = _nextId++;
            users.Add(item);

            string json = JsonConvert.SerializeObject(item, Formatting.Indented);
            SaveJson();

            return item;            
        }

        public User Get(int id)
        {
            return users.Find(p => p.Id == id);
        }

        public User Get(string name)
        {
            return users.Find(p => p.Name == name);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public void Remove(int id)
        {
            users.RemoveAll(p => p.Id == id);
        }

        public bool Update(User item)
        {
            if (item == null)
                throw new ArgumentException("item");

            int index = users.FindIndex( p=> p.Id == item.Id);
            if (index < 0)
                return false;

            users[index].IsActive = item.IsActive;
            users[index].Name = item.Name;

            SaveJson();
            return true;
        }        

        private void SaveJson()
        {
            using (StreamWriter w = File.CreateText(fileDir))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(w, users);
            }
        }


    }
}
