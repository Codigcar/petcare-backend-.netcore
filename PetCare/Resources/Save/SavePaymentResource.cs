using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SavePaymentResource
    {
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string CVV { get; set; }


        [Required]
        [MaxLength(6)]
        public string DateOfExpiry { get; set; }

      

    }
}
