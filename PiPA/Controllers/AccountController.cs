using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PiPA.Data;
using PiPA.Models;
using PiPA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PiPA.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Our Register Action will create a user successfully. 
        /// </summary>
        /// <param name="rvm"></param>
        /// <returns>RegisterViewModel</returns>
        [HttpPost]
        public IActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //Create new application user
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday,
                };
            }
            return View(rvm);
        }
        /// <summary>
        /// Gets login view and returns it back to the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login() => View();

        /// <summary>
        /// Creates a Login session for the user
        /// </summary>
        /// <param name="lvm"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        /// <summary>
        /// Will succesfully sign out a user
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
