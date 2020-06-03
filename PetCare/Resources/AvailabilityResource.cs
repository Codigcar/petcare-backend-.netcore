using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class AvailabilityResource
    {
        public int Id { get; set; }
        public string DateAvailability { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
