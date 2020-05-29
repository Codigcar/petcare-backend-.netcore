using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class RequestResponse : BaseResponse
    {
        public Request Request { get; private set; }

        public RequestResponse(bool success, string message, Request request) : base(success, message)
        {
            Request = request;
        }

        public RequestResponse(Request request) : this(true, string.Empty, request) { }

        public RequestResponse(string message) : this(false, message, null) { }

    }
}
