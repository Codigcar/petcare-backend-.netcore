using AutoMapper;
using PetCare.Domain.Models;
using PetCare.Resources;
using PetCare.Resources.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomerResource, PersonProfile>();
            CreateMap<SaveProviderResource, Provider>();
            CreateMap<SavePetResource, Pet>();
            CreateMap<SaveSuscriptionPlan, SubscriptionPlan>();
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<SaveRegisterPetResource, Pet>();
            CreateMap<SaveServiceResource, Service>();
            CreateMap<SaveServiTypeResource, ServiType>();
            CreateMap<SaveProviderRepresentativeResource, ProviderRepresentative>();
            CreateMap<SaveMedicalProfileResource, MedicalProfile>();
            CreateMap<SaveMedicalRecordResource, MedicalRecord>();
            CreateMap<SaveVaccinationRecordResource,VaccinationRecord >();
            CreateMap<SaveRequestResource, PersonRequest>();

        }
    }
}
