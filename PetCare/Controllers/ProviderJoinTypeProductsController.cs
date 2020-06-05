﻿using System;
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
    [Route("api/business/{businessId}/providers/{providerId}/typeproducts")]
    public class ProviderJoinTypeProductsController : ControllerBase
    {
      //  private readonly IService
        private readonly IProviderJoinProductService _providerJoinProducts;
        private readonly IMapper _mapper;

        public ProviderJoinTypeProductsController(IProviderJoinProductService providerJoinProduct, IMapper mapper)
        {
            _providerJoinProducts = providerJoinProduct;
            _mapper = mapper;
        }
        
        [HttpPost("{typeproductId}")]
        public async Task<IActionResult> AssignTypeProduct(int providerId, int typeproductId)
        {

          var result = await _providerJoinProducts.AssignProviderProduct(providerId, typeproductId);
            if (!result.Success)
                return BadRequest(result.Message);

            //var tagResource = _mapper.Map<Service, ServiceResource>(result.ProviderJoinService.Service);
            return Ok();
           
        }
    

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllTypeProductByProviderId(int providerId)
        {
            var servicess = await _providerJoinProducts.ListByProviderIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(servicess);
            return resources;
        }

    }
}