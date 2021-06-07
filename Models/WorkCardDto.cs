using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCardAPI.Models
{
    public class WorkCardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Order { get; set; }
        public string Technology { get; set; }
        public int NumberOfOperations { get; set; }
        public DateTime StartPoint { get; set; }
        public DateTime EndPoint { get; set; }
        // Duration prop was excluded here...
        // Below comes from Employee properties (flatted):
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        // Operations sub-entity
        public List<OperationDto> Operations { get; set; }

    }
}
