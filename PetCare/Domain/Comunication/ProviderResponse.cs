using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ProviderResponse : BaseResponse
    {
        public Provider ServicesProvider { get; private set; }
        public ProviderResponse(bool success, string message, Provider servicesProvider) : base(success, message)
        {
            ServicesProvider = servicesProvider;
        }
        public ProviderResponse(Provider servicesProvider) : this(true, string.Empty, servicesProvider)
        { }

        public ProviderResponse(string message) : this(false, message, null) { }
    }
}
