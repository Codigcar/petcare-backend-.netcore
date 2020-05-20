using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Repositories
{
    public class ProviderJoinServiceRepository : BaseRepository, IProviderJoinServiceRepository
    {
        public ProviderJoinServiceRepository(AppDbContext context) : base(context) { }


        public async Task AssignProviderService(int providerId, int serviceId)
        {
            ProviderJoinService providerJoinService = await FindByProviderIdAndServiceId(providerId, serviceId);
            if (providerJoinService == null)
            {
                providerJoinService = new ProviderJoinService { ProviderId = providerId, ServiceId = serviceId };
                await _context.ProviderJoinServices.AddAsync(providerJoinService);
            }
        }

        public async Task<ProviderJoinService> FindByProviderIdAndServiceId(int providerId, int serviceId)
        {
            return await _context.ProviderJoinServices.FindAsync(providerId, serviceId);
        }

        public async Task<IEnumerable<ProviderJoinService>> ListByProviderIdAsync(int providerId)
        {
            return await _context.ProviderJoinServices
               .Where(ps => ps.ProviderId == providerId)
               .Include(ps => ps.Provider)
               .Include(ps => ps.Service)
               .ToListAsync();
        }

        public async Task<IEnumerable<ProviderJoinService>> ListByServiceIdAsync(int serviceId)
        {
            return await _context.ProviderJoinServices
               .Where(ps => ps.ServiceId == serviceId)
               .Include(ps => ps.Provider)
               .Include(ps => ps.Service)
               .ToListAsync();
        }
    }
}
