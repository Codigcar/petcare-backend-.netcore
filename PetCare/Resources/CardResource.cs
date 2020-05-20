using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class CardResource
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public string Name { get; set; }
 
        public string  CVV { get; set; }
  
        public string Expiry_Date { get; set; }


    }
}
