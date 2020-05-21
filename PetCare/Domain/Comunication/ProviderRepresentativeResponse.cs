using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ProviderRepresentativeResponse:BaseResponse
    {
        public ProviderRepresentative ProviderRepresentative { get; private set; }

        public ProviderRepresentativeResponse(bool success, string message, ProviderRepresentative providerrepresentative) : base(success, message)
        {
            ProviderRepresentative = providerrepresentative;
        }

        public ProviderRepresentativeResponse(ProviderRepresentative providerrepresentative) : this(true, string.Empty, providerrepresentative) { }

        public ProviderRepresentativeResponse(string message) : this(false, message, null) { }
    }
}
