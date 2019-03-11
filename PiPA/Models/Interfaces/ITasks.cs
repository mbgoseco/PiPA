using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Models.Interfaces
{
    public interface ITasks
    {
        Task CreateTask(Tasks tasks);
        Task<Tasks> GetOneTask(int id);
        Task<List<Tasks>> GetAllTasks();
        Task UpdateTask(Tasks tasks);
        Task DeleteTask(int id);
    }
}
