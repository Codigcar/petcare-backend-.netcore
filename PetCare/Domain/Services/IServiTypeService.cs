using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IServiTypeService
    {
        Task<IEnumerable<ServiType>> ListAsync();
        Task<ServiTypeResponse> SaveAsync(ServiType serviType);
        //Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        //Task<CustomerResponse> DeleteAsync(int id);
        //Task<CustomerResponse> FindByIdAsync(int id);
    }
}
