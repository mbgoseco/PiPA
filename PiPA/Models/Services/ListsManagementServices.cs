using Microsoft.EntityFrameworkCore;
using PiPA.Data;
using PiPA.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Models.Services
{
    public class ListsManagementServices : ILists
    {
        private PADbcontext _context { get; }
        /// <summary>
        /// makes a connection to the PA database
        /// </summary>
        /// <param name="context">the PA database</param>
        public ListsManagementServices(PADbcontext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a list item in the list table
        /// </summary>
        /// <param name="lists">the list to add</param>
        /// <returns>returns when the task is done</returns>
        public async Task CreateList(Lists lists)
        {
            _context.ListsTable.Add(lists);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a list item from the list table
        /// </summary>
        /// <param name="id">the ID of the list one wants to delete</param>
        /// <returns>returns when the task is done</returns>
        public async Task DeleteList(int id)
        {
            Lists lists = await _context.ListsTable.FindAsync(id);
            if (lists != null)
            {
                _context.ListsTable.Remove(lists);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// gets all the lists in the table
        /// </summary>
        /// <returns>a list of the lists</returns>
        public async Task<List<Lists>> GetAllLists()
        {
            return await _context.ListsTable.ToListAsync();
        }

        /// <summary>
        /// gets one list from the table
        /// </summary>
        /// <param name="id">the list of the userid you want</param>
        /// <returns>the list of that user</returns>
        public async Task<int> GetOneListId(string id)
        {
            Lists lists = await _context.ListsTable.FirstOrDefaultAsync(t => t.UserID == id);
            return lists.ID;
        }

        /// <summary>
        /// updates the table with the "new" list/details
        /// </summary>
        /// <param name="lists">the revised list object</param>
        /// <returns>returns when the task is done</returns>
        public async Task UpdateList(Lists lists)
        {
            _context.ListsTable.Update(lists);
            await _context.SaveChangesAsync();
        }
    }
}
