using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveBusinessProfileResource
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        public string Document { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(2)]
        public string Age { get; set; }


        public Boolean Owner { get; set; }

        public int ProviderId { get; set; }
    }
}
