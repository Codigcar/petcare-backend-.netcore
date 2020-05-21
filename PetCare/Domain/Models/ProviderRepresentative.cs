using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class ProviderRepresentative
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Direction { get; set; }


        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

    }
}
