using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IServicesProviderService
    {
        Task<IEnumerable<ServicesProvider>> ListAsync();
        Task<ServicesProviderResponse> SaveAsync(ServicesProvider servicesProvider);
        Task<ServicesProviderResponse> UpdateAsync(int id, ServicesProvider servicesProvider);
        Task<ServicesProviderResponse> DeleteAsync(int id);
    }
}
