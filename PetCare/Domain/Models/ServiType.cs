using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class ServiType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Service> ListServices { get; set; } = new List<Service>();
    }
}
