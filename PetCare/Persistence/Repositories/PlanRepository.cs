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
    public class PlanRepository : BaseRepository, IPlanRepository
    {
        public PlanRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
        }

        public async Task<Plan> FindByIdAsync(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public void Remove(Plan plan)
        {
            _context.Plans.Remove(plan);
        }

        public void Update(Plan customer)
        {
            _context.Update(customer);
        }
    }
}
