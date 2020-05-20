using PetCare.Domain.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IServiceS
    {
        Task<ServiceResponse> findByName(string name);
    }
}
