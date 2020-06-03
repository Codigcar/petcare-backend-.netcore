using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class ProviderJoinProduct
    {
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
