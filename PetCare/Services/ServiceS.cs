﻿using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class ServiceS : IServiceS
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceS(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse> findByName(string name)
        {
            try
            {
                var service = await _serviceRepository.FindByNameAsync(name);
                return new ServiceResponse(service);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred the ServiceType: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Service>> ListByServiTypeIdAsync(int serviTypeId)
        {
            return await _serviceRepository.ListByServiTypeIdAsync(serviTypeId);
        }

        public async Task<ServiceResponse> SaveByServiTypeIdAsync(int serviTypeId, Service service)
        {
            try
            {
                await _serviceRepository.SaveByServiTypeIdAsync(serviTypeId, service);
                await _unitOfWork.CompleteAsync();

                return new ServiceResponse(service);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while saving the ServiceType: {ex.Message}");
            }
        }
    }
}