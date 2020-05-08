using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task AddAsyn(Plan plan);
        Task<Plan> FindByIdAsync(int id);
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
