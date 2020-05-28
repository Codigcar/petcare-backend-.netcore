using AutoMapper;
using PetCare.Domain.Models;
using PetCare.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();
            CreateMap<Provider, ProviderResource>();
            CreateMap<Pet, PetResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<SuscriptionPlan, SuscriptionPlanResource>();
            CreateMap<Pet, RegisterPetResource>();
            CreateMap<Service, ServiceResource>();
            CreateMap<ServiType, ServiTypeResource>();
            CreateMap<ProviderRepresentative, ProviderRepresentativeResource>();
            CreateMap<MedicalProfile, MedicalProfileResource>();
            CreateMap<MedicalRecord, MedicalRecordResource>();
            CreateMap<VaccinationRecord, VaccinationRecordResource>();
}
    }
}
