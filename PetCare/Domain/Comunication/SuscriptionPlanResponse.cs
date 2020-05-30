using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class SuscriptionPlanResponse : BaseResponse
    {
        public SuscriptionPlan SuscriptionPlan { get; private set; }

        public SuscriptionPlanResponse(bool success, string message, SuscriptionPlan suscriptionPlan) : base(success, message)
        {
            SuscriptionPlan = suscriptionPlan;
        }

        public SuscriptionPlanResponse(SuscriptionPlan suscriptionPlan) : this(true, string.Empty, suscriptionPlan) { }

        public SuscriptionPlanResponse(string message) : this(false, message, null) { }

    }
}
