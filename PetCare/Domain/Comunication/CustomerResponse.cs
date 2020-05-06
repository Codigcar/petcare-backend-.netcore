using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class CustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }

        public CustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            Customer = customer;
        }

        public CustomerResponse(Customer customer) : this(true, string.Empty, customer) { }

        public CustomerResponse(string message) : this(false, message, null) { }

    }
}