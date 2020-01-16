using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManager.API.Models;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces.Services;
using UserManager.Infra.CrossCutting.Identity.Config;

namespace UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationUserManager _userManager;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ApplicationUserManager userManager, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        public async Task<ActionResult> Create([FromBody]UserViewModelCreate model)
        {
            string result = string.Empty;

            if (ModelState.IsValid)
            {

                User user = new User
                {
                    UserName = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                };

                result = await _userService.CreateUserAsync(user);

                if (result == "User has been created successfully")
                {
                    return Created("", result);
                }
            }
            else
            {
                return BadRequest(result);
            }

            return BadRequest(model);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] UserViewModelUpdate model, [FromRoute] string id)
        {
            string result = string.Empty;

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Name,
                    Email = model.Email
                };

                result = await _userService.UpdateUserAsync(id, user);

                if (result == "User has been updated successfully")
                {
                    return NoContent();
                }
            }
            else
            {
                return NotFound(result);
            }

            return BadRequest(model);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                result = await _userService.DeleteUserAsync(id);

                if (result == "User has been deleted successfully")
                {
                    return Ok(result);
                }
            }
            else
            {
                return NotFound(result);
            }

            return BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> ListUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{name}")]
        [HttpGet]
        public ActionResult GetByName([FromRoute] string name)
        {
            var result =  _userService.GetUserByName(name);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}