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
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceS _service;
        private readonly IMapper _mapper;

        public ServiceController(IServiceS service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string name, [FromBody] SaveServiceResource saveServiceResource)
        {
            //string name = "peluqueria";
            var result = await _service.findByName(saveServiceResource.Name);
            return Ok(result);


        }


    }
}