using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Controllers
{
    [Route("api/provider/{providerId}/providerrepresentative")]
    public class ProviderRepresentativeController:ControllerBase
    {

        private readonly IProviderRepresentativeService _providerrepresentativeService;
        private readonly IMapper _mapper;

        public ProviderRepresentativeController(IProviderRepresentativeService providerrepresentativeService, IMapper mapper)
        {
            _providerrepresentativeService = providerrepresentativeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProviderRepresentativeResource>> GetAllAsync(int providerId)
        {

            var providerrepresentatives = await _providerrepresentativeService.ListByProviderIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<ProviderRepresentative>, IEnumerable<ProviderRepresentativeResource>>(providerrepresentatives);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int providerId, [FromBody] SaveProviderRepresentativeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var providerrepresentative = _mapper.Map<SaveProviderRepresentativeResource, ProviderRepresentative>(resource);
            var result = await _providerrepresentativeService.SaveByProviderIdAsync(providerId, providerrepresentative);
            if (!result.Success)
                return BadRequest(result.Message);
            var providerrepresentativeResource = _mapper.Map<ProviderRepresentative, ProviderRepresentativeResource>(result.ProviderRepresentative);
            return Ok(providerrepresentativeResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProviderRepresentativeResource resource)
        {
            var providerrepresentative = _mapper.Map<SaveProviderRepresentativeResource, ProviderRepresentative>(resource);
            var result = await _providerrepresentativeService.UpdateAsync(id, providerrepresentative);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var providerrepresentativeResource = _mapper.Map<ProviderRepresentative, ProviderRepresentativeResource>(result.ProviderRepresentative);
            return Ok(providerrepresentativeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _providerrepresentativeService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<ProviderRepresentative, ProviderRepresentativeResource>(result.ProviderRepresentative);
            return Ok(categoryResource);
        }
    }
}
