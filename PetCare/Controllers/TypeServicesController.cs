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
    [Route("api/servicetype/{servicetypeId}/service")]
    public class TypeServicesController : ControllerBase
    {
        private readonly IServiceS _service;
        private readonly IMapper _mapper;

        public TypeServicesController(IServiceS service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string name,[FromBody] SaveServiceResource saveServiceResource)
        {
            //string name = "peluqueria";
            var result = await _service.findByName(saveServiceResource.Name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveServiceByTypeIdAsync(int servicetypeId, [FromBody] SaveServiceResource saveServiceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var entity = _mapper.Map<SaveServiceResource, Service>(saveServiceResource);
            var result = await _service.SaveByServiTypeIdAsync(servicetypeId, entity);
            if (!result.Success)
                return BadRequest(result.Message);

            var Resource = _mapper.Map<Service, ServiceResource>(result.Service);
            return Ok(Resource);
        }


        [HttpGet]
        public async Task<IEnumerable<ServiceResource>> GetAllByServiceTypeIdAsync(int servicetypeId)
        {
            var services = await _service.ListByServiTypeIdAsync(servicetypeId);
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return resources;
        }


    }
}