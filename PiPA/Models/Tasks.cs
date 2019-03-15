using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public int ListID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime PlannedDateComplete { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
