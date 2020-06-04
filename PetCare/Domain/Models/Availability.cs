using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public string DayAvailability { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        //
    }
}
