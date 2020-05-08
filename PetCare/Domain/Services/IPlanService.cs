using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<PlanResponse> SaveAsync(Plan customer);
        Task<PlanResponse> UpdateAsync(int id, Plan customer);
        Task<PlanResponse> DeleteAsync(int id);
        Task<PlanResponse> FindByIdAsync(int id);
    }
}
