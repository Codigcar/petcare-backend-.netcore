using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task<PetResponse> SaveAsync(Pet pet);
        Task<PetResponse> UpdateAsync(int id, Pet pet);
        Task<PetResponse> DeleteAsync(int id);
    }
}
