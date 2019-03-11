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
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        private readonly ApplicationDbcontext _user;
        //private readonly IEmailSender _emailSender;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbcontext user/*, IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _user = user;
            //_emailSender = emailSender;
        }


        /// <summary>
        /// Default Register Page
        /// </summary>
        /// <returns>Return the View of the Register Page</returns>

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
                    return RedirectToAction("Index", "Home");
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

        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        [HttpGet]

        public async Task<IActionResult> ExternalLoginCallback(string error = null)
        {
            // Redirect if there is an error
            if (error != null)
            {
                // Logs the error
                TempData["Error"] = "Error with Provider";
                return RedirectToAction("Login");
            }

            // Checks provider for support
            var info = await _signInManager.GetExternalLoginInfoAsync();

            // Makes them login with a different technique if web app deos not support the provider
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Login with the external provider
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            // Redirect them home if the login was a success
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            //Get the email if this is the first time
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            //Redirect to the external login page for the user
            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
        }
        [HttpPost]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information";
                }
                var user = new ApplicationUser()
                {
                    UserName = elvm.Email,
                    Email = elvm.Email,
                    FirstName = elvm.firstName,
                    LastName = elvm.lastName
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    await _userManager.AddClaimAsync(user, fullNameClaim);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        //Sign in the user with their information
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            return View("ExternalLogin", elvm);
        }
    }
}
