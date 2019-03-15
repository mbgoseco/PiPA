using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiPA.Models
{
    public class Lists
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string ListName { get; set; }

        public List<Tasks> TaskList { get; set; }
    }
}
