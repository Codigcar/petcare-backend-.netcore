using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class CardResource
    {
  
        public string Number { get; set; }

        public string Name { get; set; }
 
        public string  CVV_Number { get; set; }
  
        public string Expiry_Date { get; set; }


    }
}
