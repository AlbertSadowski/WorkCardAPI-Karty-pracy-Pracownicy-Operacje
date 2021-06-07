using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCardAPI.Models
{
    public class UpdateWorkCardDto
    {
        [Required]
        [MaxLength(25)]
        public string CardNumber { get; set; }
        public string Order { get; set; }
        public string Technology { get; set; }
        
    }
}
