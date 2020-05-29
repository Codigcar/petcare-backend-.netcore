using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IRequestService
    {
        Task<RequestResponse> SaveByCustomerIdAsync(int customerId,int providerId,int servicesId, int petId, Request Request);
        Task<IEnumerable<Request>> ListByCostumerIdAsync(int customerId);
        Task<IEnumerable<Request>> ListByServiceIdAsync(int providerId,int serviceId);
    }
}
