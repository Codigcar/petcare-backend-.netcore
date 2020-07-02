using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Account
    {
       
        public int Id { get; set; }
        [Required]
        public string User { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public int RolId { get; set; }

        public PersonProfile PersonProfile { get; set; }
        
        public BusinessProfile BusinessProfile { get; set; }

        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }

       
    }
}
