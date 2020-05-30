using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ServiceResponse : BaseResponse
    {
        public Service Service { get; private set; }

        public ServiceResponse(bool success, string message, Service service) : base(success, message)
        {
            Service = service;
        }

        public ServiceResponse(Service service) : this(true, string.Empty, service) { }

        public ServiceResponse(string message) : this(false, message, null) { }

    }
}

