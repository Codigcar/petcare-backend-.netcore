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
    public class ServicesProviderService : IServicesProviderService
    {
        private readonly IServicesProviderRepository _servicesProviderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServicesProviderService(IServicesProviderRepository servicesProviderRepository, IUnitOfWork unitOfWork)
        {
            _servicesProviderRepository = servicesProviderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServicesProviderResponse> DeleteAsync(int id)
        {
            var existingservicesProvider = await _servicesProviderRepository.FindByIdAsync(id);

            if (existingservicesProvider == null)
                return new ServicesProviderResponse("servicesProvider not found.");

            try
            {
                _servicesProviderRepository.Remove(existingservicesProvider);
                await _unitOfWork.CompleteAsync();
                return new ServicesProviderResponse(existingservicesProvider);
            }
            catch (Exception ex)
            {
                return new ServicesProviderResponse($"An error ocurred while deleting the servicesProvider: {ex.Message}");
            }
           
        }

        public async Task<IEnumerable<ServicesProvider>> ListAsync()
        {
            return await _servicesProviderRepository.ListAsync();
        }

        public async Task<ServicesProviderResponse> SaveAsync(ServicesProvider servicesProvider)
        {
            try
            {
                await _servicesProviderRepository.AddAsyn(servicesProvider);
                await _unitOfWork.CompleteAsync();

                return new ServicesProviderResponse(servicesProvider);
            }
            catch (Exception ex)
            {
                return new ServicesProviderResponse($"An error ocurred while saving the servicesProvider: {ex.Message}");
            }
        }

        public async Task<ServicesProviderResponse> UpdateAsync(int id, ServicesProvider servicesProvider)
        {
            var existingServicesProvider = await _servicesProviderRepository.FindByIdAsync(id);

            if (existingServicesProvider == null)
                return new ServicesProviderResponse("servicesProvider not found");

            existingServicesProvider.BusinessName = servicesProvider.BusinessName;
            existingServicesProvider.Address = servicesProvider.Address;
            existingServicesProvider.Description = servicesProvider.Description;
            existingServicesProvider.Email = servicesProvider.Email;
            existingServicesProvider.Field = servicesProvider.Field;
            existingServicesProvider.Region = servicesProvider.Region;
            existingServicesProvider.SuscriptionPlanId = servicesProvider.SuscriptionPlanId;

            try
            {
                _servicesProviderRepository.Update(existingServicesProvider);
                await _unitOfWork.CompleteAsync();

                return new ServicesProviderResponse(existingServicesProvider);
            }
            catch (Exception ex)
            {
                return new ServicesProviderResponse($"An error ocurred while updating the servicesProvider: {ex.Message}");
            }
        }


        public async Task<IEnumerable<ServicesProvider>> ListBySuscriptionPlanIdAsync(int categoryId)
        {
            return await _servicesProviderRepository.ListBySuscriptionPlanIdAsync(categoryId);

        } 
    }
}
