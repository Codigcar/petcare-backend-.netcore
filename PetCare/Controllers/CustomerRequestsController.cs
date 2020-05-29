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
    [Route("api/customers/{customerId}/pets/{petId}/servicesproviders/{providerId}/services/{servicesId}/request")]
    public class CustomerRequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public CustomerRequestsController(IRequestService RequestService, IMapper mapper)
        {
            _requestService = RequestService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int customerId, int providerId, int servicesId, int petId, [FromBody] SaveRequestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var request = _mapper.Map<SaveRequestResource, Request>(resource);
            var result = await _requestService.SaveByCustomerIdAsync(customerId, providerId, servicesId, petId, request);
            if (!result.Success)
                return BadRequest(result.Message);
            var requestResource = _mapper.Map<Request, RequestResource>(result.Request);
            return Ok(requestResource);
        }

    }
}