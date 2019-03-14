using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PiPA.Models;

namespace PiPA.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// calls the home page
        /// </summary>
        /// <returns>returns the home page view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
