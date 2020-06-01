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
    [Route("api/providers/{providerId}/services")]
    public class ProviderJoinServiceController : ControllerBase
    {
      //  private readonly IService
        private readonly IProviderJoinServiceS _providerJoinService;
        private readonly IMapper _mapper;

        public ProviderJoinServiceController(IProviderJoinServiceS providerJoinService, IMapper mapper)
        {
            _providerJoinService = providerJoinService;
            _mapper = mapper;
        }
        
        [HttpPost("{serviceId}")]
        public async Task<IActionResult> AssignProductTag(int providerId, int serviceId)
        {

            var result = await _providerJoinService.AssignProviderService(providerId, serviceId);
            if (!result.Success)
                return BadRequest(result.Message);

            //var tagResource = _mapper.Map<Service, ServiceResource>(result.ProviderJoinService.Service);
            return Ok();

        }
    

        [HttpGet]
        public async Task<IEnumerable<ServiceResource>> GetAllByProviderIdAsync(int providerId)
        {
            var servicess = await _providerJoinService.ListByProviderIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(servicess);
            return resources;
        }

    }
}