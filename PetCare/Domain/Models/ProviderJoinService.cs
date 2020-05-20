using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class ProviderJoinService
    {
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
