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
    [Route("api/customers/{customerId}/pets/{petId}/medicalprofiles")]
    public class PetMedicalProfilesController : ControllerBase
    {
        private readonly IMedicalProfileService _medicalprofileService;
        private readonly IMapper _mapper;

        public PetMedicalProfilesController(IMedicalProfileService medicalprofileService, IMapper mapper)
        {
            _medicalprofileService = medicalprofileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalProfileResource>> GetAllAsync(int petId)
        {
            var customers = await _medicalprofileService.ListByPetIdAsync(petId);
            var resources = _mapper.Map<IEnumerable<MedicalProfile>, IEnumerable<MedicalProfileResource>>(customers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int customerId, [FromBody] SaveMedicalProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var medicalprofile = _mapper.Map<SaveMedicalProfileResource, MedicalProfile>(resource);
            var result = await _medicalprofileService.SaveByPetIdAsync(customerId, medicalprofile);
            if (!result.Success)
                return BadRequest(result.Message);
            var MedicalProfileResource = _mapper.Map<MedicalProfile, MedicalProfileResource>(result.MedicalProfile);
            return Ok(MedicalProfileResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicalProfileResource resource)
        {
            var medicalprofile = _mapper.Map<SaveMedicalProfileResource, MedicalProfile>(resource);
            var result = await _medicalprofileService.UpdateAsync(id, medicalprofile);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var medicalprofileResource = _mapper.Map<MedicalProfile, MedicalProfileResource>(result.MedicalProfile);
            return Ok(medicalprofileResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _medicalprofileService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<MedicalProfile, MedicalProfileResource>(result.MedicalProfile);
            return Ok(categoryResource);
        }
    }
}