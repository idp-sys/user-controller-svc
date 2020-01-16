using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManager.API.Models;
using UserManager.Application.Interfaces.Services;
using UserManager.Domain.Entities;
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

        public UserController(ApplicationUserManager userManager,  IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
      
        public async  Task<ActionResult> Create([FromBody]UserViewModel model)
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

            return BadRequest(result);
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> EditAsync([FromBody] UserViewModel model, [FromRoute] string id)
        //{
        //    var user = _mapper.Map<User>(model);

        //    var result = await _userService.UpdateUser(id, user, _userManager).ConfigureAwait(true);

        //    if (result.Succeeded)
        //    {
        //        return Ok(result.Succeeded);
        //    }


        //    return Ok(result.Errors);

        //}

        //[HttpDelete("{id:int}", Name = "Delete")]
        //public async Task<ActionResult> DeleteAsync([FromRoute] string id)
        //{
        //    var result = await _userService.DeleteUser(id, _userManager).ConfigureAwait(true);

        //    if (result.Succeeded)
        //    {
        //        return Ok(result.Succeeded);
        //    }


        //    return Ok(result.Errors);
        //}

        //[HttpGet]
        //public ActionResult GetAllUser()
        //{
        //    var result = _userService.GetAllusers(_userManager);

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }

        //    return Ok("Falha");
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult> GetByIdAsync([FromRoute] string id)
        //{
        //    var result = await _userService.GetUserById(id, _userManager).ConfigureAwait(true);


        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }


        //    return Ok("Falha");
        //}

        //[HttpGet("{name}")]
        //public async Task<ActionResult> GetbynameAsync([FromRoute] string name)
        //{
        //    var result = await _userService.GetUserByName(name, _userManager).ConfigureAwait(true);

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }


        //    return Ok("Falha");
        //}
    }
}