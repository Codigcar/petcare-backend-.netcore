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
    public class ServiTypeRepository : BaseRepository, IServiTypeRepository
    {
        public ServiTypeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(ServiType serviType)
        {
             await _context.ServiTypes.AddAsync(serviType);
        }

        public async Task<IEnumerable<ServiType>> ListAsync()
        {
            return await _context.ServiTypes.ToListAsync();
        }
    }
}
