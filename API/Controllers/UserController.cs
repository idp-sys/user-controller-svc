using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Domain.Entities;
using Service.Services;
using Service.Validators;

namespace UserController.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration configuration;

        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        private BaseService<User> service = new BaseService<User>();

        /// <summary>
        /// Cadastra Usuário
        /// </summary>
        /// <param name="item">Usuário</param>
        /// <returns>usuário</returns>
        /// <response code="200">Usuário inserido com sucesso.</response>
        /// <response code="400">ID inválido</response>
        /// <response code="400">Nome inválido</response>
        /// <response code="400">Status inválido</response>
        /// <response code="500">Erro do servidor.</response>
        [HttpPost("add")]
        public IActionResult Post([FromBody] User item)
        {
            try
            {
                service.Post<UserValidator>(item, configuration.GetConnectionString("LiteDb"));

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (LiteException ex)
            {
                if (ex.ErrorCode == 110)
                {
                    return ValidationProblem("Usuário existente com este ID");
                }

                return Problem("Ligar para suporte");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errorDictionary = new ModelStateDictionary();
                foreach (var error in ex.Errors)
                {
                    errorDictionary.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
                return ValidationProblem(errorDictionary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos usuários cadastrados
        /// </summary>
        /// <response code="200">Usuários listados com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet("getList")]
        [SwaggerOperation(Description = "Lista todos os usuários cadastrados.")]
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

        /// <summary>
        /// Consulta o usuário
        /// </summary>
        /// <param name="id">ID do usuário a ser consultado</param>
        /// <response code="200">Usuário pesquisado com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet("getbyid/{id}")]
        [SwaggerOperation(Description = "Pesquisa o usuário com o ID.")]
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

        /// <summary>
        /// Consulta o usuário
        /// </summary>
        /// <param name="name">Nome do usuário a ser consultado</param>
        /// <response code="200">Usuário pesquisado com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet("getbyname/{name}")]
        [SwaggerOperation(Description = "Pesquisa o usuário com o nome.")]
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

        /// <summary>
        /// Deleta usuário
        /// </summary>
        /// <param name="id">ID do usuário a ser consultado</param>
        /// <response code="200">Usuário deletado com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpDelete("delete/{id}")]
        [SwaggerOperation(Description = "Deletando o usuário com o ID.")]
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

        /// <summary>
        /// Atualiza usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="name">Novo nome do usuário</param>
        /// <param name="status">Novo status do usuário</param>
        /// <response code="200">Atualização efetuada com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPut("update/{id}")]
        [SwaggerOperation(Description = "Atualização do usuário.")]
        public IActionResult Put(int id, [FromQuery]string name, [FromQuery]string status)
        {
            try
            {
                service.Put<UserValidator>(id, configuration.GetConnectionString("LiteDb"), name, status);

                return new ObjectResult(id);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errorDictionary = new ModelStateDictionary();
                foreach (var error in ex.Errors)
                {
                    errorDictionary.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
                return ValidationProblem(errorDictionary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}