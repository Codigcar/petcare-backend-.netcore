using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveCardResource
    {
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string CVV_Number { get; set; }


        [Required]
        [MaxLength(8)]
        public string DateOfExpiry { get; set; }

      

    }
}
