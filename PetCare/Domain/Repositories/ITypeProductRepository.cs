using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface ITypeProductRepository
    {
        Task<IEnumerable<TypeProduct>> ListAsync();
        Task AddAsyn(TypeProduct typeProduct);
       // Task<Customer> FindByIdAsync(int id);
       // void Update(Customer customer);
       // void Remove(Customer customer);
    }
}
