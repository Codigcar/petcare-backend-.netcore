using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class PlanResponse : BaseResponse
    {
        public Plan Plan { get; private set; }

        public PlanResponse(bool success, string message, Plan plan) : base(success, message)
        {
            Plan = plan;
        }

        public PlanResponse(Plan plan) : this(true, string.Empty, plan) { }

        public PlanResponse(string message) : this(false, message, null) { }

    }
}
