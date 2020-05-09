using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface ISuscriptionPlanRepository
    {
        Task<IEnumerable<SuscriptionPlan>> ListAsync();
        Task AddAsyn(SuscriptionPlan suscriptionPlan);
        Task<SuscriptionPlan> FindByIdAsync(int id);
        void Update(SuscriptionPlan suscriptionPlan);
        void Remove(SuscriptionPlan suscriptionPlan);
    }
}
