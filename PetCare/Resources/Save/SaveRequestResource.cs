using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveRequestResource
    {
       
        public DateTime DateReservation { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Status { get; set; }

    }
}
