using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UserController.Domain.Entities;
using UserController.Service.Services;

namespace UserController.API.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration configuration;

        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        private BaseService<User> service = new BaseService<User>();

        [HttpPost("adicionar")]
        public IActionResult Post([FromBody] User item)
        {
            try
            {
                service.Post(item, configuration.GetConnectionString("LiteDb"));

                return new ObjectResult(item.Id);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get(configuration.GetConnectionString("LiteDb")));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("buscarId/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id, configuration.GetConnectionString("LiteDb")));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("buscarNome/{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                return new ObjectResult(service.Get(name, configuration.GetConnectionString("LiteDb")));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("removerId/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id, configuration.GetConnectionString("LiteDb"));

                return new NoContentResult();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Put(int id, [FromQuery]string name, [FromQuery]string status)
        {
            try
            {
                return new ObjectResult(id);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}