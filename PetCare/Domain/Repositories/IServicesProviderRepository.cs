using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IServicesProviderRepository
    {
        Task<IEnumerable<ServicesProvider>> ListAsync();
        Task AddAsyn(ServicesProvider servicesProvider);
        Task<ServicesProvider> FindByIdAsync(int id);
        void Update(ServicesProvider servicesProvider);
        void Remove(ServicesProvider servicesProvider);
    }
}
