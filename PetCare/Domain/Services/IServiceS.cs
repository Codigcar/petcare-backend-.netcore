using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IServiceS
    {
        Task<ServiceResponse> findByName(string name);
        Task<ServiceResponse> SaveByServiTypeIdAsync(int serviTypeId, Service service);
        Task<IEnumerable<Service>> ListByServiTypeIdAsync(int serviTypeId);
    }
}
