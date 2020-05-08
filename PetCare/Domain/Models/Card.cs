using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public short CVV_Number { get; set; }
        public string Expiry_Date{ get; set; }
        
    }
}
