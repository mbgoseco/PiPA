using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiPA.Models;
using PiPA.Models.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PiPA.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasks _tasks;
        public TasksController(ITasks tasks)
        {
            _tasks = tasks;
        }

        public async Task<IActionResult> Index()
        {
            //might need to go back to get task by user
            return View(await _tasks.GetAllTasks());
        }

        public async Task<IActionResult> Details(int id)
        {
            var oneTask = await _tasks.GetOneTask(id);

            return View(oneTask);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var oneTask = await _tasks.GetOneTask(id);
            if (oneTask == null)
            {
                return NotFound();
            }
            return View(oneTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, ListID, TaskName, Description, DateCreated, PlannedDateComplete, CompleteDate, IsComplete")] Tasks tasks)
        {
            await _tasks.UpdateTask(tasks);
            return RedirectToAction(nameof(Index));
        }

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

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _tasks.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
