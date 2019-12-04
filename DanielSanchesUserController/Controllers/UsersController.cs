using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanielSanchesUserController.Models;
using DanielSanchesUserController.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DanielSanchesUserController.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        static readonly IUserRepository repository = new UserRepository();
        
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }


        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            User user = repository.Get(id);
            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet("/name/{name}", Name = "GetUserByName")]
        public IActionResult GetUserByName(string name)
        {
            User user = repository.Get(name);
            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult AddUser([FromBody]User value)
        {
            if (value == null)
                return BadRequest();

            value = repository.Add(value);
            return CreatedAtRoute("GetUser", new { id = value.Id }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User value)
        {
            if (value == null)
                return BadRequest();

            value.Id = id;
            if (!repository.Update(value))
                return NotFound();

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User item = repository.Get(id);
            if (item == null)
                return BadRequest();

            repository.Remove(id);
            return new NoContentResult();
        }
    }
}
