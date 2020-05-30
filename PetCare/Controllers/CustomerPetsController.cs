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
    [Route("api/customers/{customerId}/pets")]
    public class CustomerPetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerPetsController(ICustomerService customerService,IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<PetResource>> GetAllAsync(int customerId)
        {
            var customers = await _petService.ListByCostumerIdAsync(customerId);
            var resources = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(customers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int customerId, [FromBody] SavePetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var Cid = await _customerService.FindByIdAsync(customerId
            );
            if (!Cid.Success)
                return BadRequest(Cid.Message);

            var pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.SaveByCustomerIdAsync(customerId, pet);
            if (!result.Success)
                return BadRequest(result.Message);
            var petResource = _mapper.Map<Pet, PetResource>(result.Pet);
            return Ok(petResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int customerId,int id, [FromBody] SavePetResource resource)
        {
            var Cid = await _customerService.FindByIdAsync(customerId
            );
            if (!Cid.Success)
                return BadRequest(Cid.Message);
            var pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.UpdateAsync(id, pet);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var petResource = _mapper.Map<Pet, PetResource>(result.Pet);
            return Ok(petResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int customerId,int id)
        {
            var Cid = await _customerService.FindByIdAsync(customerId
            );
            if (!Cid.Success)
                return BadRequest(Cid.Message);
            var result = await _petService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Pet, PetResource>(result.Pet);
            return Ok(categoryResource);
        }
    }
}