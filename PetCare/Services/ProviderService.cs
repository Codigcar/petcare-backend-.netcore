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
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _servicesProviderRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository servicesProviderRepository, IUnitOfWork unitOfWork)
        {
            _servicesProviderRepository = servicesProviderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProviderResponse> DeleteAsync(int id)
        {
            var existingservicesProvider = await _servicesProviderRepository.FindByIdAsync(id);

            if (existingservicesProvider == null)
                return new ProviderResponse("servicesProvider not found.");

            try
            {
                _servicesProviderRepository.Remove(existingservicesProvider);
                await _unitOfWork.CompleteAsync();
                return new ProviderResponse(existingservicesProvider);
            }
            catch (Exception ex)
            {
                return new ProviderResponse($"An error ocurred while deleting the servicesProvider: {ex.Message}");
            }

        }

        public async Task<IEnumerable<Provider>> ListAsync()
        {
            return await _servicesProviderRepository.ListAsync();
        }

        public async Task<ProviderResponse> SaveAsync(Provider servicesProvider)
        {
            try
            {
                await _servicesProviderRepository.AddAsyn(servicesProvider);
                await _unitOfWork.CompleteAsync();

                return new ProviderResponse(servicesProvider);
            }
            catch (Exception ex)
            {
                return new ProviderResponse($"An error ocurred while saving the servicesProvider: {ex.Message}");
            }
        }

        public async Task<ProviderResponse> UpdateAsync(int id, Provider servicesProvider)
        {
            var existingServicesProvider = await _servicesProviderRepository.FindByIdAsync(id);

            if (existingServicesProvider == null)
                return new ProviderResponse("servicesProvider not found");

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

                return new ProviderResponse(existingServicesProvider);
            }
            catch (Exception ex)
            {
                return new ProviderResponse($"An error ocurred while updating the servicesProvider: {ex.Message}");
            }
        }


        public async Task<IEnumerable<Provider>> ListBySuscriptionPlanIdAsync(int categoryId)
        {
            return await _servicesProviderRepository.ListBySuscriptionPlanIdAsync(categoryId);

        }

        public async Task<ProviderResponse> FindByIdAsync(int id)
        {

            try
            {
                var provider = await _providerRepository.FindByIdAsync(id);
                return new ProviderResponse(provider);
            }
            catch (Exception ex)
            {
                return new ProviderResponse($"An error ocurred while deleting the provider: {ex.Message}");
            }
        }


    }
}
