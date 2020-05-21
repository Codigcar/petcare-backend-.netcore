using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string StartTime { get; set; }
        public bool status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
       
    }
}
