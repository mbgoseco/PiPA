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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data for 1 lists
            modelBuilder.Entity<Lists>().HasData(
               new Lists
               {
                   ID = 1,
                   UserID = "1",
                   ListName = "ToDo" 
               });

            //seed data for 3 tasks
            modelBuilder.Entity<Tasks>().HasData(
               new Tasks
               {
                   ID = 1,
                   ListID = 1,
                   TaskName = "Mow the Lawn",
                   Description = "Mow the lawn description",
                   DateCreated = new DateTime(2019, 3, 1, 7, 0, 0),
                   PlannedDateComplete = new DateTime(2019, 3, 7, 15, 0, 0),
                   CompletedDate = new DateTime(2019, 3, 8, 10, 30, 0),
                   IsComplete = false
               },
               new Tasks
               {
                   ID = 2,
                   ListID = 1,
                   TaskName = "Do the Dishes",
                   Description = "Do the Dishes description",
                   DateCreated = new DateTime(2019, 3, 11, 7, 0, 0),
                   PlannedDateComplete = new DateTime(2019, 3, 11, 15, 0, 0),
                   CompletedDate = new DateTime(2019, 3, 11, 18, 0, 0),
                   IsComplete = false
               },
               new Tasks
               {
                   ID = 3,
                   ListID = 1,
                   TaskName = "Go Grocery Shopping",
                   Description = "Go Grocery Shopping description",
                   DateCreated = new DateTime(2019, 3, 10, 7, 0, 0),
                   PlannedDateComplete = new DateTime(2019, 3, 18, 17, 0, 0),
                   CompletedDate = new DateTime(2019, 3, 18, 17, 0, 0),
                   IsComplete = false
               }
               );
        }

        public DbSet<Lists> ListsTable { get; set; }
        public DbSet<Tasks> TasksTable { get; set; }
    }
}
