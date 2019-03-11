﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
