using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCardAPI.Entities
{
    public class WorkCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Order { get; set; }
        public string Technology { get; set; }
        public int NumberOfOperations { get; set; }
        public DateTime StartPoint { get; set; }
        public DateTime EndPoint { get; set; }
        public int Duration { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<Operation> Operations { get; set; }
    }
}
