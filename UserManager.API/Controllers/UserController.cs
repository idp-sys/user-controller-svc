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


        // GET: User/Details/5
        public ActionResult Details(UserViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.UpdateUser(user. _userManager).ConfigureAwait(true);
            if (result.Succeeded)
            {
                return Json(result.Succeeded);
            }

            return Json(result.Errors);
        }

      
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}