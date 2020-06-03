using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class RequestResource
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Status { get; set; }

        public int CustomerId { get; set; }
        public int PetId { get; set; }
        public int ServiceId { get; set; }
    }
}
