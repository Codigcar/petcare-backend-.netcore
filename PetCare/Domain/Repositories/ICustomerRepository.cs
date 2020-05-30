using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task AddAsyn(Customer customer);
        Task<Customer> FindByIdAsync(int id);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
