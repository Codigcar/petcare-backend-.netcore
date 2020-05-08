using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class CardResource
    {
        [Required]
        public long Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public short  CVV_Number { get; set; }
        [Required]
        public string Expiry_Date { get; set; }


    }
}
