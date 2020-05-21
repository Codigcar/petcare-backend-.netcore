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
    public class ProviderRepresentativeRepository:BaseRepository, IProviderRepresentativeRepository
    {
        public ProviderRepresentativeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(ProviderRepresentative providerrepresentative)
        {
            await _context.ProviderRepresentatives.AddAsync(providerrepresentative);
        }

        public async Task<ProviderRepresentative> FindByIdAsync(int id)
        {
            return await _context.ProviderRepresentatives.FindAsync(id);
        }

        public async Task<IEnumerable<ProviderRepresentative>> ListAsync()
        {
            return await _context.ProviderRepresentatives.ToListAsync();
        }

        public void Remove(ProviderRepresentative providerrepresentative)
        {
            _context.ProviderRepresentatives.Remove(providerrepresentative);
        }

        public void Update(ProviderRepresentative providerrepresentative)
        {
            _context.Update(providerrepresentative);
        }


        public async Task SaveByProviderIdAsync(int providerId, ProviderRepresentative providerrepresentative)
        {
            var provider = await _context.ServicesProviders.FindAsync(providerId);
            providerrepresentative.ProviderId = provider.Id;
            await _context.ProviderRepresentatives.AddAsync(providerrepresentative);
        }

        public async Task<IEnumerable<ProviderRepresentative>> ListByProviderIdAsync(int providerId) =>

            await _context.ProviderRepresentatives
            .Where(p => p.ProviderId == providerId)
            .Include(p => p.Provider)
            .ToListAsync();
    }
}
