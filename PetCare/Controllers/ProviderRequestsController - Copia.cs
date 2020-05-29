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
    [Route("api/servicesproviders/{providerId}/services/{serviceId}/request")]
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
        public async Task<IEnumerable<RequestResource>> GetAllByServiceIdAsync(int providerId, int serviceId)
        {
            var requests = await _requestService.ListByServiceIdAsync(providerId, serviceId);
            var resources = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);
            return resources;
        }

    }
}