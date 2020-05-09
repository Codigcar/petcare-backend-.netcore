using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class ServicesProviderResource : User
    {
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
