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
    public class AvailabilityRepository : BaseRepository, IAvailabilityRepository
    {
        public AvailabilityRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Availability availability)
        {
            await _context.Availabilities.AddAsync(availability);
        }

        public async Task<Availability> FindByIdAsync(int id)
        {
            return await _context.Availabilities.FindAsync(id);
        }

        public async Task<IEnumerable<Availability>> ListAsync()
        {
            return await _context.Availabilities.ToListAsync();
        }

        public async Task<IEnumerable<Availability>> ListByServiceIdAsync(int serviceId)=>
            await _context.Availabilities
            .Where(p => p.ServiceId == serviceId)
            .Include(p => p.Service)
            .ToListAsync();

        public void Remove(Availability availability)
        {
            _context.Availabilities.Remove(availability);
        }

        public async Task SaveByServiceIdAsync(int providerId, int serviceId, Availability availability)
        {
            var provider = await _context.ServicesProviders.FindAsync(providerId);
            var provider_join_services = await _context.ProviderJoinServices.FindAsync(providerId, serviceId);
            availability.ProviderId = provider_join_services.ProviderId;
            availability.ServiceId= provider_join_services.ServiceId;
            await _context.Availabilities.AddAsync(availability);
        }

        public void Update(Availability availability)
        {
            _context.Update(availability);
        }
    }
}
