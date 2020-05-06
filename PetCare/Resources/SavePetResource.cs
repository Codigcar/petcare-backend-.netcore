using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SavePetResource
    {
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        [MaxLength(30)]
        public string Breed { get; set; }
        [Required]
        [MaxLength(50)]
        public string Photo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sex { get; set; }

    }
}
