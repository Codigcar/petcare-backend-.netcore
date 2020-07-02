using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;

namespace PetCare.Controllers
{
    [Route("api/business/{business}/providers/{providerId}/request")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService RequestService, IMapper mapper)
        {
            _requestService = RequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequestResource>> GetAllRequestByProductId(int providerId)
        {
            var requests = await _requestService.ListByProductIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<PersonRequest>, IEnumerable<RequestResource>>(requests);
            return resources;
        }
        [HttpPut("{requestId}")]
        public async Task<IActionResult> EditRequest(int requestId, [FromBody] SaveRequestResource resource )
        {
            var request = _mapper.Map<SaveRequestResource, PersonRequest>(resource);
            var result = await _requestService.Update(requestId, request);
            if(!result.Success)
            {
                return BadRequest(result.Message); 
            }
            var requestresource = _mapper.Map<PersonRequest, RequestResource>(result.Request);

            return Ok(requestresource);
        }
       /* [HttpPut("{id}")]
        public async Task<IActionResult> EditPeopleRegister(int id, [FromBody] SavePersonProfileResource resource)
        {
            var customer = _mapper.Map<SavePersonProfileResource, PersonProfile>(resource);
            var result = await _customerService.UpdateAsync(id, customer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<PersonProfile, PersonProfileResource>(result.Customer);
            return Ok(customerResource);
        }*/

    }
}