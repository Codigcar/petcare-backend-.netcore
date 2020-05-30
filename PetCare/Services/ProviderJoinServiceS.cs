using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class ProviderJoinServiceS : IProviderJoinServiceS
    {
        private readonly IProviderJoinServiceRepository _providerJoinServiceRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderJoinServiceS(IProviderJoinServiceRepository providerJoinServiceRepository, IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _providerJoinServiceRepository = providerJoinServiceRepository;
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

       
    public async Task<ProviderJoinServiceResponse> AssignProviderService(int providerId, int serviceId)
    {
       try
       {

           await _providerJoinServiceRepository.AssignProviderService(providerId, serviceId);
           await _unitOfWork.CompleteAsync();
           ProviderJoinService providerJoinService = await _providerJoinServiceRepository.FindByProviderIdAndServiceId(providerId, serviceId);
           return new ProviderJoinServiceResponse(providerJoinService);
       }
       catch (Exception ex)
       {
           return new ProviderJoinServiceResponse($"An error ocurred while assigning service to provider: {ex.Message}");
       }
    }


    public async Task<IEnumerable<Service>> ListByProviderIdAsync(int providerId)
    {
    // return await _providerJoinServiceRepository.ListByProviderIdAsync(providerId);
    var providerService = await _providerJoinServiceRepository.ListByProviderIdAsync(providerId);
    var services = providerService.Select(ps => ps.Service).ToList();
    return services;
    }


    }
}
