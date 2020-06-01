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
    [Route("api/typeproducts")]
    public class TypeController : ControllerBase
    {
        private readonly IServiTypeService _serviTypeService;
        private readonly IMapper _mapper;

        public TypeController(IServiTypeService serviTypeService, IMapper mapper)
        {
            _serviTypeService = serviTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiTypeResource>> GetAllAsync()
        {
            var typeProducts = await _serviTypeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ServiType>, IEnumerable<ServiTypeResource>>(typeProducts);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync( [FromBody] SaveServiTypeResource saveServiTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var serviType = _mapper.Map<SaveServiTypeResource, ServiType>(saveServiTypeResource);
            var result = await _serviTypeService.SaveAsync(serviType);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper.Map<ServiType, ServiTypeResource>(result.ServiType);
            return Ok(resource);
        }


    }
}