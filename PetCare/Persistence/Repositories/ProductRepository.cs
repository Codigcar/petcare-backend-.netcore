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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        { }

        public Task<Product> FindByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FindByNameAsync(string name)
        {
            /* return await _context.Services
                 .Where(pt => pt.Name == name)
                 .FirstOrDefaultAsync();*/

            return await _context.Products.Where(a => a.Name == name).FirstAsync();
        }

        public Task<IEnumerable<Product>> ListByTypeProductIdAsync(int typeProductId)
        {
            throw new NotImplementedException();
        }

        public Task SaveByTypeProductIdAsync(int typeProductId, Product product)
        {
            throw new NotImplementedException();
        }

        /*  public async Task<IEnumerable<Product>> ListByTypeProductIdAsync(int serviTypeId) => 
              await _context.Products
              .Where(s => s.TypeProductId == serviTypeId)
              .Include(i => i.TypeProduct)
              .ToListAsync();


          public async Task SaveByTypeProductIdAsync(int serviTypeId, Product service)
          {
              var serviType = await _context.TypeProducts.FindAsync(serviTypeId);
              service.TypeProductId = serviType.Id; 
              await _context.Products.AddAsync(service);

          }
          public async Task<Product> FindByIdAsync(int serviceId)
          {
              return await _context.Products.FindAsync(serviceId);
          }*/
    }
}
