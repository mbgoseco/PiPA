﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Models.Interfaces
{
    interface ILists
    {
        Task CreateList(Lists lists);
        Task<Lists> GetOneList(int id);
        Task<List<Lists>> GetAllLists();
        Task UpdateList(Lists lists);
        Task DeleteList(int id);
    }
}
