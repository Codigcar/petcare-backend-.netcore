using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IServiTypeRepository
    {
        Task<IEnumerable<ServiType>> ListAsync();
        Task AddAsyn(ServiType serviType);
       // Task<Customer> FindByIdAsync(int id);
       // void Update(Customer customer);
       // void Remove(Customer customer);
    }
}
