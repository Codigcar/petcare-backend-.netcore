using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IProviderJoinServiceS
    {
        Task<ProviderJoinServiceResponse> AssignProviderService(int providerId, Service service);
        Task<IEnumerable<Service>> ListByProviderIdAsync(int providerId);
        Task<IEnumerable<ProviderJoinService>> ListByServiceIdAsync(int serviceId);
    }
}
