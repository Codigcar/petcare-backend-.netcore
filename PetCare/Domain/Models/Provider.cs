using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Provider : User
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Region { get; set; }
        public string Field { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public int SuscriptionPlanId { get; set; }
        public SuscriptionPlan SuscriptionPlan { get; set; }

        public Card Card { get; set; }

        public List<ProviderJoinService> ProviderServices { get; set; }

        public IList<ProviderRepresentative> ProviderRepresentatives { get; set; } = new List<ProviderRepresentative>();

        //     public IList<Card> Card { get; set; } = new List<ServicesProvider>();
    }
}
