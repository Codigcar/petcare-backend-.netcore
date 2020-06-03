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
    public class ProviderJoinProductRepository : BaseRepository, IProviderJoinProductRepository
    {
        public ProviderJoinProductRepository(AppDbContext context) : base(context) { }

      
       
       public async Task AssignProviderProduct(int providerId, int productId)
       {
           ProviderJoinProduct providerJoinProduct = await FindByProviderIdAndProductId(providerId, productId);
           if (providerJoinProduct == null)
           {
                providerJoinProduct = new ProviderJoinProduct { ProviderId = providerId, ProductId = productId };
               await _context.ProviderJoinProducts.AddAsync(providerJoinProduct);
           }
       }

        public async Task<ProviderJoinProduct> FindByProviderIdAndProductId(int providerId, int productId)
        {
            return await _context.ProviderJoinProducts.FindAsync(providerId, productId);
        }

        public async Task<IEnumerable<ProviderJoinProduct>> ListByProviderIdAsync(int providerId)
         {
             return await _context.ProviderJoinProducts
                .Where(ps => ps.ProviderId == providerId)
                .Include(ps => ps.Provider)
                .Include(ps => ps.Product)
                .ToListAsync();
         }

         public async Task<IEnumerable<ProviderJoinProduct>> ListByProductIdAsync(int providerId)
         {
             return await _context.ProviderJoinProducts
                .Where(ps => ps.ProductId == providerId)
                .Include(ps => ps.Provider)
                .Include(ps => ps.Product)
                .ToListAsync();
         }
    }
}
