using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalProfileRepository;
        private readonly IUnitOfWork _unitOfWork;


        public MedicalRecordService(IMedicalRecordRepository medicalProfileRepository, IUnitOfWork unitOfWork)
        {
            _medicalProfileRepository = medicalProfileRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<MedicalRecordResponse> SaveByProfileIdAsync(int profileId, MedicalRecord medicalRecord)
        {
            try
            {
                await _medicalProfileRepository.SaveByMedicalProfile(profileId, medicalRecord);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordResponse(medicalRecord);
            }
            catch (Exception ex)
            {
                return new MedicalRecordResponse($"An error ocurred while saving the medicalRecord: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MedicalRecord>> ListByProfileIdAsync(int profileId)
        {
            return await _medicalProfileRepository.ListByMedicalProfile(profileId);
        }
    }
}
