using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ServiTypeResponse : BaseResponse
    {
        public ServiType ServiType { get; private set; }

        public ServiTypeResponse(bool success, string message, ServiType serviType) : base(success, message)
        {
            ServiType = serviType;
        }

        public ServiTypeResponse(ServiType serviType) : this(true, string.Empty, serviType) { }

        public ServiTypeResponse(string message) : this(false, message, null) { }

    }
}
