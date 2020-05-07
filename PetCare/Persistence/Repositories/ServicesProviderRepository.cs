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
    public class ServicesProviderRepository : BaseRepository, IServicesProviderRepository
    {
        public ServicesProviderRepository(AppDbContext context) : base(context)
        { }

        public async Task AddAsyn(ServicesProvider servicesProvider)
        {
            await _context.ServicesProviders.AddAsync(servicesProvider);
        }

        public async Task<ServicesProvider> FindByIdAsync(int id)
        {
            return await _context.ServicesProviders.FindAsync(id);
        }

        public async Task<IEnumerable<ServicesProvider>> ListAsync()
        {
            return await _context.ServicesProviders.ToListAsync();
        }

        public void Remove(ServicesProvider servicesProvider)
        {
            _context.ServicesProviders.Remove(servicesProvider);
        }

        public void Update(ServicesProvider servicesProvider)
        {
            _context.Update(servicesProvider);
        }
    }
}
