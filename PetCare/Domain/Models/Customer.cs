using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Password { get; set; }

        public IList<Pet> Pets { get; set; } = new List<Pet>();

        public Account Account { get; set; }
        public int AccountId { get; set; }
        

    }
}
