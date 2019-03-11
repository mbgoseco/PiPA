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

        public Task CreateList(Lists lists)
        {
            throw new NotImplementedException();
        }

        public Task DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lists>> GetAllLists()
        {
            throw new NotImplementedException();
        }

        public Task<Lists> GetOneList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateList(Lists lists)
        {
            throw new NotImplementedException();
        }
    }
}
