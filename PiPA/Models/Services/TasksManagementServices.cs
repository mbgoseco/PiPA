using Microsoft.EntityFrameworkCore;
using PiPA.Data;
using PiPA.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Models.Services
{
    public class TasksManagementServices : ITasks
    {
        private PADbcontext _context { get; }
        /// <summary>
        /// makes a connectiong to the database
        /// </summary>
        /// <param name="context">the databade</param>
        public TasksManagementServices(PADbcontext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds a task to the table
        /// </summary>
        /// <param name="tasks">the task object one wants to add</param>
        /// <returns>returns when the task is done</returns>
        public async Task CreateTask(Tasks tasks)
        {
            _context.TasksTable.Add(tasks);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a a task from the table
        /// </summary>
        /// <param name="id">the id of the task one wants to remove</param>
        /// <returns>returns when it is done</returns>
        public async Task DeleteTask(int id)
        {
            Tasks tasks = await _context.TasksTable.FindAsync(id);
            if (tasks != null)
            {
                _context.TasksTable.Remove(tasks);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// gets all tasks in the table
        /// </summary>
        /// <returns>a list of all the tasks</returns>
        public async Task<List<Tasks>> GetAllTasksForAList(int id)
        {
            var taskItems = from ti in _context.TasksTable
                            .Where(i => i.ListID == id)
                            select ti;
            return await taskItems.ToListAsync();
        }

        /// <summary>
        /// gets one task from the table 
        /// </summary>
        /// <param name="id">the task id you want</param>
        /// <returns>the task</returns>
        public async Task<Tasks> GetOneTask(int id)
        {
            Tasks tasks = await _context.TasksTable.FirstOrDefaultAsync(t => t.ID == id);
            return tasks;
        }

        /// <summary>
        /// updates the task in the table
        /// </summary>
        /// <param name="tasks">the revised task object</param>
        /// <returns>returns when the task is done</returns>
        public async Task UpdateTask(Tasks tasks)
        {
            _context.TasksTable.Update(tasks);
            await _context.SaveChangesAsync();
        }
    }
}
