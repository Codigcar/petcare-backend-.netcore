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
            var existingCategory = await _servicesProviderRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ServicesProviderResponse("Category not found.");

            try
            {
                _servicesProviderRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new ServicesProviderResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new ServicesProviderResponse($"An error ocurred while deleting the Category: {ex.Message}");
            }
            throw new NotImplementedException();
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
                return new ServicesProviderResponse($"An error ocurred while saving the category: {ex.Message}");
            }
        }

        public async Task<ServicesProviderResponse> UpdateAsync(int id, ServicesProvider servicesProvider)
        {
            var existingServicesProvider = await _servicesProviderRepository.FindByIdAsync(id);

            if (existingServicesProvider == null)
                return new ServicesProviderResponse("Category not found");

            existingServicesProvider.BusinessName = servicesProvider.BusinessName;
            existingServicesProvider.Address = servicesProvider.Address;
            existingServicesProvider.Description = servicesProvider.Description;
            existingServicesProvider.Email = servicesProvider.Email;
            existingServicesProvider.Field = servicesProvider.Field;
            existingServicesProvider.Region = servicesProvider.Region;

            try
            {
                _servicesProviderRepository.Update(existingServicesProvider);
                await _unitOfWork.CompleteAsync();

                return new ServicesProviderResponse(existingServicesProvider);
            }
            catch (Exception ex)
            {
                return new ServicesProviderResponse($"An error ocurred while updating the Category: {ex.Message}");
            }
        }
    }
}
