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

namespace PetCare.Controllers
{
    [Route("api/providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _servicesProviderService;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderService servicesProviderService, IMapper mapper)
        {
            _servicesProviderService = servicesProviderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProviderResource>> GetAllAsync()
        {

            var servicesProviders = await _servicesProviderService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderResource>>(servicesProviders);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveProviderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var servicesProvider = _mapper.Map<SaveProviderResource, Provider>(resource);
            var result = await _servicesProviderService.SaveAsync(servicesProvider);
            if (!result.Success)
                return BadRequest(result.Message);
            var servicesProviderResource = _mapper.Map<Provider, ProviderResource>(result.ProductsProvider);
            return Ok(servicesProviderResource);



        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProviderResource resource)
        {
            var servicesProvider = _mapper.Map<SaveProviderResource, Provider>(resource);
            var result = await _servicesProviderService.UpdateAsync(id, servicesProvider);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var servicesProviderResource = _mapper.Map<Provider, ProviderResource>(result.ProductsProvider);
            return Ok(servicesProviderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _servicesProviderService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Provider, ProviderResource>(result.ProductsProvider);
            return Ok(categoryResource);
        }

    }
}