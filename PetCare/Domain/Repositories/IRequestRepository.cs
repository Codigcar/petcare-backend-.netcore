using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task SaveByCustomerIdAsync(PersonRequest request);
        Task<PersonRequest> FindByIdAsync(int id);
        void Update(PersonRequest request);
        Task<IEnumerable<PersonRequest>> ListByCustomerIdAsync(int customerId);
        Task<IEnumerable<PersonRequest>> ListByProductIdAsync(int serviceId);
    }
}
