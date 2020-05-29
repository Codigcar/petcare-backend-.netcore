using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Many-to-Many
        public List<ProviderJoinService> ProviderServices { get; set; }

        //One-To-Many
        public ServiType ServiType { get; set; }
        public int ServiTypeId { get; set; }

        public IList<Request> Requests { get; set; } = new List<Request>();
    }
}
