using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IServiceRepository
    {
        //Task<> FindByIdAsync(int serviceId);
        Task<Service> FindByNameAsync(string name);
    }
}
