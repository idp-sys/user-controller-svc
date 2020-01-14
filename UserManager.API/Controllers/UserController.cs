using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManager.API.Models;
using UserManager.Application.Interfaces.Services;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces.Services;
using UserManager.Infra.CrossCutting.Identity.Config;

namespace UserManager.API.Controllers
{

    public class UserController : Controller
    {

        //private IidentityApplicationUserManager _userManager;

        private ApplicationUserManager _userManager;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ApplicationUserManager userManager , IUserService userService , IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }



        //POST: User/Create
        [HttpPost]
        [AllowAnonymous]
        public  async Task<JsonResult> Create(UserViewModel model)
        {
    
            var user = _mapper.Map<User>(model);

            var result = await _userService.CreateUser(user,_userManager).ConfigureAwait(true);
            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(UserViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.UpdateUser(user, _userManager).ConfigureAwait(true);

            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.UpdateUser(user, _userManager).ConfigureAwait(true);

            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

        // GET: User/Details/5
        public async Task<ActionResult> UpdateUser(UserViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.UpdateUser(user, _userManager).ConfigureAwait(true);
        
            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

      
    }
}