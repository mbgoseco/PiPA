using Microsoft.EntityFrameworkCore;
using PiPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Data
{
    public class PADbcontext : DbContext
    {
        public PADbcontext(DbContextOptions<PADbcontext> options) : base(options)
        {
        }

        public DbSet<Lists> ListsTable { get; set; }
        public DbSet<Tasks> TasksTable { get; set; }
    }
}
