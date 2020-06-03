using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;

namespace PetCare.Controllers
{
    [Route("api/providers/{providerId}/products")]
    public class ProviderJoinProductController : ControllerBase
    {
      //  private readonly IService
        private readonly IProviderJoinProductService _providerJoinProducts;
        private readonly IMapper _mapper;

        public ProviderJoinProductController(IProviderJoinProductService providerJoinProduct, IMapper mapper)
        {
            _providerJoinProducts = providerJoinProduct;
            _mapper = mapper;
        }
        
        [HttpPost("{serviceId}")]
        public async Task<IActionResult> AssignProductTag(int providerId, int serviceId)
        {

            var result = await _providerJoinProducts.AssignProviderProduct(providerId, serviceId);
            if (!result.Success)
                return BadRequest(result.Message);

            //var tagResource = _mapper.Map<Service, ServiceResource>(result.ProviderJoinService.Service);
            return Ok();

        }
    

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByProviderIdAsync(int providerId)
        {
            var servicess = await _providerJoinProducts.ListByProviderIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(servicess);
            return resources;
        }

    }
}