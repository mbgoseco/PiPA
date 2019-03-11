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
        public TasksManagementServices(PADbcontext context)
        {
            _context = context;
        }

        public async Task CreateTask(Tasks tasks)
        {
            if (await _context.TasksTable.FirstOrDefaultAsync(t => t.ID == tasks.ID) == null)
            {
                _context.TasksTable.Add(tasks);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            Tasks tasks = await _context.TasksTable.FindAsync(id);
            if (tasks != null)
            {
                _context.TasksTable.Remove(tasks);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            return await _context.TasksTable.ToListAsync();
        }

        public async Task<Tasks> GetOneTask(int id)
        {
            Tasks tasks = await _context.TasksTable.FirstOrDefaultAsync(t => t.ID == id);
            return tasks;
        }

        public async Task UpdateTask(Tasks tasks)
        {
            _context.TasksTable.Update(tasks);
            await _context.SaveChangesAsync();
        }
    }
}
