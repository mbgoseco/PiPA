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
using PiPA.Models.Interfaces;


namespace PiPA.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ILists _lists;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILists lists)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _lists = lists;
        }

        [HttpGet]
        [AllowAnonymous]
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
        public async Task<IActionResult> Register(RegisterViewModel rvm)
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
                var result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //create list if they successfully log in
                    Lists userList = new Lists(); 
                    userList.UserID = user.Email;
                    userList.ListName = "To Do";
                    await _lists.CreateList(userList);
                }
                return RedirectToAction("Index", "Tasks");
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
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Tasks");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        /// <summary>
        /// Will succesfully sign out a user
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
