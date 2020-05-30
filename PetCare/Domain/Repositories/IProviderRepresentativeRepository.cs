using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IProviderRepresentativeRepository
    {
        Task<IEnumerable<ProviderRepresentative>> ListAsync();
        Task AddAsyn(ProviderRepresentative providerrepresentative);
        Task<ProviderRepresentative> FindByIdAsync(int id);
        void Update(ProviderRepresentative providerrepresentative);
        void Remove(ProviderRepresentative providerrepresentative);


        Task SaveByProviderIdAsync(int providerId, ProviderRepresentative providerrepresentative);
        Task<IEnumerable<ProviderRepresentative>> ListByProviderIdAsync(int providerId);

    }
}
