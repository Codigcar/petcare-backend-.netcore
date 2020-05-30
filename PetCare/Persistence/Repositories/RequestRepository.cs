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
        public class RequestRepository : BaseRepository, IRequestRepository
        {
            public RequestRepository(AppDbContext context) : base(context)
            {

            }

            public async Task<IEnumerable<Request>> ListByCustomerIdAsync(int customerId) =>
                await _context.Requests
                .Where(p => p.CustomerId == customerId)
                .Include(p => p.Customer)
                .ToListAsync();

            public async Task<IEnumerable<Request>> ListByServiceIdAsync(int serviceId) =>
                await _context.Requests
                .Where(p => p.ServiceId == serviceId)
                .Include(p => p.Service)
                .ToListAsync();

            public async Task SaveByCustomerIdAsync(Request request)
            {
                // var customer = await _context.Customers.FindAsync(customerId);
                // request.CustomerId = customer.Id;
                await _context.Requests.AddAsync(request);
            }
        }
 
}
