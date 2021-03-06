using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCardAPI.Models
{
    public class OperationDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int TimePrice { get; set; }
        public int WorkCardId { get; set; }
    }
}
