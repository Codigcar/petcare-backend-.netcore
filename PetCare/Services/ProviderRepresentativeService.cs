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
    public class ProviderRepresentativeService: IProviderRepresentativeService
    {
        private readonly IProviderRepresentativeRepository _providerrepresentativeRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProviderRepresentativeService(IProviderRepresentativeRepository providerrepresentativeRepository, IUnitOfWork unitOfWork)
        {
            _providerrepresentativeRepository = providerrepresentativeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProviderRepresentative>> ListAsync()
        {
            return await _providerrepresentativeRepository.ListAsync();
        }

        public async Task<ProviderRepresentativeResponse> SaveAsync(ProviderRepresentative providerrepresentative)
        {
            try
            {
                await _providerrepresentativeRepository.AddAsyn(providerrepresentative);
                await _unitOfWork.CompleteAsync();

                return new ProviderRepresentativeResponse(providerrepresentative);
            }
            catch (Exception ex)
            {
                return new ProviderRepresentativeResponse($"An error ocurred while saving the provider representative: {ex.Message}");
            }
        }

        public async Task<ProviderRepresentativeResponse> UpdateAsync(int id, ProviderRepresentative providerrepresentative)
        {
            var existingProviderRepresentative = await _providerrepresentativeRepository.FindByIdAsync(id);

            if (existingProviderRepresentative == null)
                return new ProviderRepresentativeResponse("provider representative not found");

            existingProviderRepresentative.Name = providerrepresentative.Name;
            existingProviderRepresentative.LastName = providerrepresentative.LastName;
            existingProviderRepresentative.Position = providerrepresentative.Position;
            existingProviderRepresentative.Phone1 = providerrepresentative.Phone1;
            existingProviderRepresentative.Phone2 = providerrepresentative.Phone2;
            existingProviderRepresentative.Direction = providerrepresentative.Direction;


            try
            {
                _providerrepresentativeRepository.Update(existingProviderRepresentative);
                await _unitOfWork.CompleteAsync();

                return new ProviderRepresentativeResponse(existingProviderRepresentative);
            }
            catch (Exception ex)
            {
                return new ProviderRepresentativeResponse($"An error ocurred while updating the provider representative: {ex.Message}");
            }
        }

        public async Task<ProviderRepresentativeResponse> DeleteAsync(int id)
        {
            var existingproviderrepresentative = await _providerrepresentativeRepository.FindByIdAsync(id);

            if (existingproviderrepresentative == null)
                return new ProviderRepresentativeResponse("provider representative not found.");

            try
            {
                _providerrepresentativeRepository.Remove(existingproviderrepresentative);
                await _unitOfWork.CompleteAsync();
                return new ProviderRepresentativeResponse(existingproviderrepresentative);
            }
            catch (Exception ex)
            {
                return new ProviderRepresentativeResponse($"An error ocurred while deleting the provider representative: {ex.Message}");
            }

        }

        public async Task<ProviderRepresentativeResponse> SaveByProviderIdAsync(int providerId, ProviderRepresentative providerrepresentative)
        {
            try
            {
                await _providerrepresentativeRepository.SaveByProviderIdAsync(providerId, providerrepresentative);
                await _unitOfWork.CompleteAsync();

                return new ProviderRepresentativeResponse(providerrepresentative);
            }
            catch (Exception ex)
            {
                return new ProviderRepresentativeResponse($"An error ocurred while saving the provider representative: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProviderRepresentative>> ListByProviderIdAsync(int providerId)
        {
            return await _providerrepresentativeRepository.ListByProviderIdAsync(providerId);
        }

    }
}
