using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class PersonRequest
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Status { get; set; }

        public int PersonProfileId { get; set; }
        public PersonProfile PersonProfile { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PetId { get; set; }
        public int ProviderId { get; set; }

    }
}
