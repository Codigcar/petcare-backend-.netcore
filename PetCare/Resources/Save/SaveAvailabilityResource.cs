using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveAvailabilityResource
    {
        [Required]
        [MaxLength(10)]
        public string DateAvailability { get; set; }

        [Required]
        [MaxLength(4)]
        public string StartTime { get; set; }

        [Required]
        [MaxLength(4)]
        public string EndTime { get; set; }
    }
}
