using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ProviderJoinServiceResponse : BaseResponse
    {
        public ProviderJoinService ProviderJoinService { get; private set; }

        public ProviderJoinServiceResponse(bool success, string message, ProviderJoinService providerJoinService) : base(success, message)
        {
            ProviderJoinService = providerJoinService;
        }

        public ProviderJoinServiceResponse(ProviderJoinService providerJoinService) : this(true, string.Empty, providerJoinService) { }

        public ProviderJoinServiceResponse(string message) : this(false, message, null) { }
    }
}
