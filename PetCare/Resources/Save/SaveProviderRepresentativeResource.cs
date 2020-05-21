using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveProviderRepresentativeResource
    {

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position { get; set; }

        [Required]
        [MaxLength(9)]
        public string Phone1 { get; set; }

        [Required]
        [MaxLength(9)]
        public string Phone2 { get; set; }

        [Required]
        public string Direction { get; set; }
    }
}
