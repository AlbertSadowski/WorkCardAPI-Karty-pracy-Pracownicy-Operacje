using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCardAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

    }
}
