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
    public class ServiTypeService : IServiTypeService
    {
        private readonly IServiTypeRepository _serviTypeRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ServiTypeService(IServiTypeRepository serviTypeRepository, IUnitOfWork unitOfWork)
        {
            _serviTypeRepository = serviTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ServiType>> ListAsync()
        {
            return await _serviTypeRepository.ListAsync();
        }

        public async Task<ServiTypeResponse> SaveAsync(ServiType serviType)
        {
            try
            {
                await _serviTypeRepository.AddAsyn(serviType);
                await _unitOfWork.CompleteAsync();

                return new ServiTypeResponse(serviType);
            }
            catch (Exception ex)
            {
                return new ServiTypeResponse($"An error ocurred while saving : {ex.Message}");
            }
        }
    }
}
