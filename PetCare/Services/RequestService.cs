using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IPersonProfileRepository _customerRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IPetRepository _petRepository;
        private readonly IProviderRepository _providerRepository;


        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IRequestRepository requestRepository, IPersonProfileRepository customerRepository,
            IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _requestRepository = requestRepository;
            _customerRepository = customerRepository;
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonRequest>> ListByCostumerIdAsync(int customerId)
        {
            return await _requestRepository.ListByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<PersonRequest>> ListByServiceIdAsync(int providerId, int serviceId)
        {
            return await _requestRepository.ListByServiceIdAsync(serviceId);
        }

        public async Task<RequestResponse> SaveByCustomerIdAsync(int customerId, int providerId, int servicesId, int petId, PersonRequest request)
        {
            PersonProfile customer = await _customerRepository.FindByIdAsync(customerId);
            Service service = await _serviceRepository.FindByIdAsync(servicesId);
            /*  Pet pet = await _petRepository.FindByIdAsync(petId);
              Provider provider = await _providerRepository.FindByIdAsync(providerId);*/
            try
            {
                /*    if (  pet.Id == petId )
                    {*/
                request.PetId = petId;
                request.PersonProfileId = customerId;
                request.PersonProfile = customer;
                request.ProviderId = providerId;
                request.Service = service;
                request.ServiceId = servicesId;

                await _requestRepository.SaveByCustomerIdAsync(request);
                await _unitOfWork.CompleteAsync();
                return new RequestResponse(request);
                /*      }
                      return new RequestResponse("not found request");
                      */
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while saving the request: {ex.Message}");
            }
        }
    }
}
