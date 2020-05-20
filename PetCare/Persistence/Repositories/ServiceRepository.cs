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
    }
}
