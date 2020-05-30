using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IProviderRepresentativeService
    {
        Task<IEnumerable<ProviderRepresentative>> ListAsync();
        Task<ProviderRepresentativeResponse> SaveAsync(ProviderRepresentative providerrepresentative);
        Task<ProviderRepresentativeResponse> UpdateAsync(int id, ProviderRepresentative providerrepresentative);
        Task<ProviderRepresentativeResponse> DeleteAsync(int id);

        Task<ProviderRepresentativeResponse> SaveByProviderIdAsync(int providerId, ProviderRepresentative providerrepresentative);
        Task<IEnumerable<ProviderRepresentative>> ListByProviderIdAsync(int providerId);
    }
}
