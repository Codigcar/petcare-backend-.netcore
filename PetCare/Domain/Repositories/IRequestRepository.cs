using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task SaveByCustomerIdAsync(Request request);
        Task<IEnumerable<Request>> ListByCustomerIdAsync(int customerId);
        Task<IEnumerable<Request>> ListByServiceIdAsync(int serviceId);
    }
}
