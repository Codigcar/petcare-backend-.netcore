﻿using AutoMapper;
using PetCare.Domain.Models;
using PetCare.Resources;
using PetCare.Resources.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<PersonProfile, CustomerResource>();
            CreateMap<Provider, ProviderResource>();
            CreateMap<Pet, PetResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<SubscriptionPlan, SuscriptionPlanResource>();
            CreateMap<Pet, RegisterPetResource>();
            CreateMap<Service, ServiceResource>();
            CreateMap<ServiType, ServiTypeResource>();
            CreateMap<ProviderRepresentative, ProviderRepresentativeResource>();
            CreateMap<MedicalProfile, MedicalProfileResource>();
            CreateMap<MedicalRecord, MedicalRecordResource>();
            CreateMap<VaccinationRecord, VaccinationRecordResource>();
            CreateMap<PersonRequest, RequestResource>();
            CreateMap<Availability, AvailabilityResource>();

        }
    }
}
