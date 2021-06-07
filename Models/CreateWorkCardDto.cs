using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCardAPI.Models
{
    public class CreateWorkCardDto
    {

        [Required]
        [MaxLength(25)]
        public string CardNumber { get; set; }
        public string Order { get; set; }
        public string Technology { get; set; }
        public int NumberOfOperations { get; set; }
        public DateTime StartPoint { get; set; }
        public DateTime EndPoint { get; set; }
        public int Duration { get; set; }
        // Below comes from Employee properties:
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
