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
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessProfileService _businessService;
        private readonly IMapper _mapper;

        public BusinessController(IBusinessProfileService businessService, IMapper mapper)
        {
            _businessService = businessService;
            _mapper = mapper;
        }

    

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveBusinessProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var businessProfile = _mapper.Map<SaveBusinessProfileResource, BusinessProfile>(resource);
            var result = await _businessService.SaveAsync(businessProfile);
            if (!result.Success)
                return BadRequest(result.Message);
            var customerResource = _mapper.Map<BusinessProfile, BusinessProfileResource>(result.BusinessProfile);
            return Ok(customerResource);
        }


     
    }
}