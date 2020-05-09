using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string CVV_Number { get; set; }
        public string Expiry_Date{ get; set; }

        public int ServicesProviderForeignKey { get; set; }
        public ServicesProvider ServicesProvider { get; set; }

    }
}
