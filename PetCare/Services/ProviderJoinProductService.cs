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
    public class ProviderJoinProductService : IProviderJoinProductService
    {
        private readonly IProviderJoinProductRepository _providerJoinProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderJoinProductService(IProviderJoinProductRepository providerJoinProductRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _providerJoinProductRepository = providerJoinProductRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

       
    public async Task<ProviderJoinProductResponse> AssignProviderProduct(int providerId, int productId)
    {
       try
       {

           await _providerJoinProductRepository.AssignProviderProduct(providerId, productId);
           await _unitOfWork.CompleteAsync();
           ProviderJoinProduct providerJoinService = await _providerJoinProductRepository.FindByProviderIdAndProductId(providerId, productId);
           return new ProviderJoinProductResponse(providerJoinService);
       }
       catch (Exception ex)
       {
           return new ProviderJoinProductResponse($"An error ocurred while assigning service to provider: {ex.Message}");
       }
    }


    public async Task<IEnumerable<Product>> ListByProviderIdAsync(int providerId)
    {
    // return await _providerJoinServiceRepository.ListByProviderIdAsync(providerId);
    var providerService = await _providerJoinProductRepository.ListByProviderIdAsync(providerId);
    var services = providerService.Select(ps => ps.Product).ToList();
    return services;
    }


    }
}
