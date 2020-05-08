using AutoMapper;
using PetCare.Domain.Models;
using PetCare.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveServicesProviderResource, ServicesProvider>();
            CreateMap<SavePetResource, Pet>();
            CreateMap<SaveCardResource, Card>();
        }
    }
}
