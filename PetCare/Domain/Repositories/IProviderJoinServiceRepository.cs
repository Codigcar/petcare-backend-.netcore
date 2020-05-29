using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IProviderJoinServiceRepository
    {
        Task<IEnumerable<ProviderJoinService>> ListByProviderIdAsync(int providerId);
        Task<IEnumerable<ProviderJoinService>> ListByServiceIdAsync(int serviceId);

        Task<ProviderJoinService> FindByProviderIdAndServiceId(int providerId, int serviceId);
        Task AssignProviderService(int providerId, int serviceId);
    }
}
