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
        //Person
        public int PersonProfileId { get; set; }
        public PersonProfile PersonProfile { get; set; }
        //Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
        //Pet
        public int PetId { get; set; }
        //Provider
        public int ProviderId { get; set; }

    }
}
