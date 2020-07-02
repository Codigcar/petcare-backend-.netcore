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
        Task<RequestResponse> SaveByCustomerIdAsync(int customerId, int providerId, int productId, int petId, PersonRequest Request);
        Task<RequestResponse> UpdateAsync(int id, PersonRequest Request);
        Task<IEnumerable<PersonRequest>> ListByCostumerIdAsync(int customerId);
        Task<IEnumerable<PersonRequest>> ListByProductIdAsync(int providerId, int productId);
    }
}
