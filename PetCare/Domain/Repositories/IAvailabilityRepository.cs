using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
      public interface IAvailabilityRepository
        {

            Task<IEnumerable<Availability>> ListAsync();
            Task AddAsyn(Availability availability);
            Task<Availability> FindByIdAsync(int id);
            void Update(Availability availability);
            void Remove(Availability availability);
            Task SaveByServiceIdAsync(int providerId, int serviceId, Availability availability);
            Task<IEnumerable<Availability>> ListByServiceIdAsync(int serviceId);
        }
}
