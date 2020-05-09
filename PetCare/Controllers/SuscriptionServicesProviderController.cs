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
    [Route("/api/suscriptionplan/{Id}/servicesprovider")]
    public class SuscriptionServicesProviderController : ControllerBase
    {
        private readonly IServicesProviderService _servicesProviderService;
        private readonly IMapper _mapper;

        public SuscriptionServicesProviderController(IServicesProviderService servicesProviderService, IMapper mapper)
        {
            _servicesProviderService = servicesProviderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServicesProviderResource>> GetAllByCategoryIdAsync(int categoryId)
        {

            var servicesProviders = await _servicesProviderService.ListBySuscriptionPlanIdAsync(categoryId);
            var resources = _mapper.Map<IEnumerable<ServicesProvider>, IEnumerable<ServicesProviderResource>>(servicesProviders);
            return resources;
        }

    }
}