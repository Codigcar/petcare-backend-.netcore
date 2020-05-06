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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _petRepository.ListAsync();
        }

        public async Task<PetResponse> SaveAsync(Pet pet)
        {
            try
            {
                await _petRepository.AddAsyn(pet);
                await _unitOfWork.CompleteAsync();

                return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while saving the category: {ex.Message}");
            }
        }

        public async Task<PetResponse> UpdateAsync(int id, Pet pet)
        {
            var existingpet = await _petRepository.FindByIdAsync(id);

            if (existingpet == null)
                return new PetResponse("Category not found");

            existingpet.Name = pet.Name;

            try
            {
                _petRepository.Update(existingpet);
                await _unitOfWork.CompleteAsync();

                return new PetResponse(existingpet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while updating the Category: {ex.Message}");
            }
        }

        public async Task<PetResponse> DeleteAsync(int id)
        {
            var existingCategory = await _petRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new PetResponse("Category not found.");

            try
            {
                _petRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while deleting the Category: {ex.Message}");
            }
            throw new NotImplementedException();
        }
    }
}
