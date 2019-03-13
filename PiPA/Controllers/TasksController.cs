using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PiPA.Models;
using PiPA.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PiPA.Controllers
{
    //[Authorize]
    public class TasksController : Controller
    {
        private readonly ITasks _tasks;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _sign;

        /// <summary>
        /// connects to task dependency injection
        /// </summary>
        /// <param name="tasks">which injection</param>
        public TasksController(ITasks tasks, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> sign)
        {
      
            _userManager = userManager;
            _tasks = tasks;
            _sign = sign;
        }

        /// <summary>
        /// gets the view to show all the tasks
        /// </summary>
        /// <returns>the task home index</returns>
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;
            var user = await _userManager.GetUserAsync(User);
            //var user = await _userManager.FindByEmailAsync(userEmail);
            if (_sign.IsSignedIn(User))
            {
                //might need to go back to get task by user
                return View(await _tasks.GetAllTasks());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            Console.WriteLine("I'm not signed in");
            return View();
        }

        /// <summary>
        /// gets the view to create a task
        /// </summary>
        /// <returns>the task create page</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Does the action to create a new task
        /// </summary>
        /// <param name="tasks">information from the form filled out on the site</param>
        /// <returns>the task home page</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, TaskName, Description, DateCreated, PlannedDateComplete")] Tasks tasks)
        {
            Tasks newtask = tasks;
            if (ModelState.IsValid)
            {
                newtask.ListID = 1; //for now since we only have one list
                newtask.CompletedDate = new DateTime(3000, 1, 1, 0, 0, 0); // since just created no complete date yet and can't do null
                newtask.IsComplete = false; // since it was just created it isn't done yet
                await _tasks.CreateTask(newtask);
                return RedirectToAction(nameof(Index));
            }
            return View(tasks);
        }

        /// <summary>
        /// gets the details of a task page
        /// </summary>
        /// <param name="id">which task</param>
        /// <returns>the specific task details page</returns>
        public async Task<IActionResult> Details(int id)
        {
            var oneTask = await _tasks.GetOneTask(id);

            return View(oneTask);
        }

        /// <summary>
        /// gets the page with the form to update a task
        /// </summary>
        /// <param name="id">which task</param>
        /// <returns>the edit task page</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var oneTask = await _tasks.GetOneTask(id);
            if (oneTask == null)
            {
                return NotFound();
            }
            return View(oneTask);
        }

        /// <summary>
        /// does the action t edit a task
        /// </summary>
        /// <param name="id">which task</param>
        /// <param name="tasks">the new revised task</param>
        /// <returns>to the task home page when done</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, TaskName, Description, PlannedDateComplete, CompletedDate, IsComplete")] Tasks tasks)
        {
            await _tasks.UpdateTask(tasks);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// gets the delete page
        /// </summary>
        /// <param name="id">which task one wants to delete</param>
        /// <returns>the task home page</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tasks = await _tasks.GetOneTask((int)id);
            await _tasks.DeleteTask((int)id);
            return RedirectToAction(nameof(Index));
        }
    }
}
