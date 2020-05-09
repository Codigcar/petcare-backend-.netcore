using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;

namespace PetCare.Controllers
{
    [Route("/api/customer/{customerId}/pet")]
    public class CustomerPetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerPetsController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int customerId,[FromBody] SaveRegisterPetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

     


            var pet = _mapper.Map<SaveRegisterPetResource, Pet>(resource);
            var result = await _petService.SaveByCustomerIdAsync(customerId,pet);
            if (!result.Success)
                return BadRequest(result.Message);
            var petResource = _mapper.Map<Pet, RegisterPetResource>(result.Pet);
            return Ok(petResource);
        }

        [HttpGet]
        public async Task<IEnumerable<PetResource>> GetListByCustomerIdAsync(int customerId)
        {

            var customers = await _petService.ListByCostumerIdAsync(customerId);
            var resources = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(customers);
            return resources;
        }

    }
}