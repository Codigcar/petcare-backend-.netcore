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
    [Route("api/servicesproviders/{servicesproviderId}/customers/{customerId}/pets/{petId}/profiles")]
    public class MedicalProfileController : ControllerBase
    {
        private readonly IMedicalProfileService _medicalprofileService;
        private readonly IMedicalRecordService _medicalrecordService;
        private readonly IMapper _mapper;

        public MedicalProfileController(IMedicalProfileService medicalprofileService, IMedicalRecordService medicalrecordService, IMapper mapper)
        {
            _medicalprofileService = medicalprofileService;
            _medicalrecordService = medicalrecordService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync(int servicesproviderId, int customerId,int petId, [FromBody] SaveMedicalProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var medicalprofile = _mapper.Map<SaveMedicalProfileResource, MedicalProfile>(resource);
            var result = await _medicalprofileService.SaveByPetIdAsync(servicesproviderId,customerId,petId, medicalprofile);
            if (!result.Success)
                return BadRequest(result.Message);
            var MedicalProfileResource = _mapper.Map<MedicalProfile, MedicalProfileResource>(result.MedicalProfile);
            return Ok(MedicalProfileResource);
        }

        [HttpPost("{profileId}/records")]
        public async Task<ActionResult> SaveByProfileId(int profileId, [FromBody] SaveMedicalRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var medicalrecord = _mapper.Map<SaveMedicalRecordResource, MedicalRecord>(resource);
            var result = await _medicalrecordService.SaveByProfileIdAsync(profileId, medicalrecord);
            if (!result.Success)
                return BadRequest(result.Message);
            var MedicalRecordResource = _mapper.Map<MedicalRecord, MedicalRecordResource>(result.MedicalRecord);
            return Ok(MedicalRecordResource);
        }

        [HttpGet("{profileId}/records")]
        public async Task<IEnumerable<MedicalRecordResource>> ListByProfileId(int profileId)
        {
           
            var result = await _medicalrecordService.ListByProfileIdAsync(profileId);
           
            var MedicalRecordResource = _mapper.Map<IEnumerable<MedicalRecord>, IEnumerable<MedicalRecordResource> >(result);
            return (MedicalRecordResource);
        }
    }
}