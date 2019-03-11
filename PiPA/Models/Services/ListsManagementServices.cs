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
        public ListsManagementServices(PADbcontext context)
        {
            _context = context;
        }

        public async Task CreateList(Lists lists)
        {
            _context.ListsTable.Add(lists);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteList(int id)
        {
            Lists lists = await _context.ListsTable.FindAsync(id);
            if (lists != null)
            {
                _context.ListsTable.Remove(lists);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Lists>> GetAllLists()
        {
            return await _context.ListsTable.ToListAsync();
        }

        public async Task<Lists> GetOneList(int id)
        {
            Lists lists = await _context.ListsTable.FirstOrDefaultAsync(t => t.ID == id);
            return lists;
        }

        public async Task UpdateList(Lists lists)
        {
            _context.ListsTable.Update(lists);
            await _context.SaveChangesAsync();
        }
    }
}
