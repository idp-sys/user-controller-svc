using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManager.API.Models;
using UserManager.Application.Interfaces.Services;
using UserManager.Domain.Entities;
using UserManager.Infra.CrossCutting.Identity.Config;

namespace UserManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
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
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]UserViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.CreateUser(user, _userManager).ConfigureAwait(true);
            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Edit([FromBody] UserViewModel model, [FromRoute] string id)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.UpdateUser(id, user, _userManager).ConfigureAwait(true);

            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _userService.DeleteUser(id, _userManager).ConfigureAwait(true);

            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAllusers(_userManager);

            if (result != null)
            {
                return Json(result);
            }

            return View();
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _userService.GetUserById(id, _userManager).ConfigureAwait(true);

            if (result != null)
            {
                return Json(result);
            }

            return View();
        }

        [HttpGet("{name:string}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var result = await _userService.GetUserByName(name, _userManager).ConfigureAwait(true);

            if (result != null)
            {
                return Json(result);
            }
            return View();
        }
    }
}