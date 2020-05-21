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
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        { }
        public async Task<Service> FindByNameAsync(string name)
        {
            /* return await _context.Services
                 .Where(pt => pt.Name == name)
                 .FirstOrDefaultAsync();*/

            return await _context.Services.Where(a => a.Name == name).FirstAsync();
        }

        public async Task<IEnumerable<Service>> ListByServiTypeIdAsync(int serviTypeId) => 
            await _context.Services
            .Where(s => s.ServiTypeId == serviTypeId)
            .Include(i => i.ServiType)
            .ToListAsync();
       

        public async Task SaveByServiTypeIdAsync(int serviTypeId, Service service)
        {
            var serviType = await _context.ServiTypes.FindAsync(serviTypeId);
            service.ServiTypeId = serviType.Id; 
            await _context.Services.AddAsync(service);

        }
    }
}
