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
using UserController.Domain.Entities;
using UserController.Service.Services;
using UserController.Service.Validators;

namespace UserController.API.Controllers
{
    [Produces("application/json")]
    [Route("user-controller")]
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
        /// <remarks>Cadastra um novo usuário.</remarks>
        /// <example>
        /// {
        ///     "name": "Daniel",
        ///     "status": "Ativo",
        ///     "id": 101
        /// }
        /// </example>
        /// <param name="item">Objeto de usuário</param>
        /// <returns>Objeto de usuário</returns>
        /// <response code="200">Usuário cadastrado com sucesso.</response>
        /// <response code="400">ID inválido</response>
        /// <response code="400">Nome inválido</response>
        /// <response code="400">Status inválido</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPost("adicionar")]
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
                    return ValidationProblem("Já existe um usuário com este ID");
                }

                return Problem("Contatar o suporte");
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
        /// Exibe os usuários cadastrados
        /// </summary>
        /// <response code="200">Usuários exibidos com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet]
        [SwaggerOperation(Description = "Exibe todos os usuários cadastrados.")]
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
        /// <response code="200">Usuário consultado com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet("buscar-por-id/{id}")]
        [SwaggerOperation(Description = "Consulta o usuário com o ID especificado.")]
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
        /// <response code="200">Usuário consultado com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet("buscar-por-nome/{name}")]
        [SwaggerOperation(Description = "Consulta o usuário com o nome especificado.")]
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
        [HttpDelete("remover-por-id/{id}")]
        [SwaggerOperation(Description = "Delete o usuário com o ID especificado.")]
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
        /// <param name="id">ID do usuário a ser atualizado</param>
        /// <param name="name">Novo nome que será dado ao usuário</param>
        /// <param name="status">Novo status que será dado ao usuário</param>
        /// <response code="200">Atualização efetuada com sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPut("atualizar/{id}")]
        [SwaggerOperation(Description = "Atualiza dados do usuário.")]
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