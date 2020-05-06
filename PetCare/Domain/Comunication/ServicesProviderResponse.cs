using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ServicesProviderResponse : BaseResponse
    {
        public ServicesProvider ServicesProvider { get; private set; }
        public ServicesProviderResponse(bool success, string message, ServicesProvider servicesProvider) : base(success, message)
        {
            ServicesProvider = servicesProvider;
        }
        public ServicesProviderResponse(ServicesProvider servicesProvider) : this(true, string.Empty, servicesProvider)
        { }

        public ServicesProviderResponse(string message) : this(false, message, null) { }
    }
}
