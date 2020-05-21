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
    [Route("api/provider/{providerId}/payment")]
    public class ProviderPayment : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public ProviderPayment(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        /* [HttpGet]
         public async Task<IEnumerable<CardResource>> GetListByCustomerIdAsync(int sproviderId)
         {
             var customers = await _cardService.ListByServicesProviderIdAsync(sproviderId);
             var resources = _mapper.Map<IEnumerable<Card>, IEnumerable<CardResource>>(customers);
             return resources;
         }*/

        [HttpPost]
        public async Task<ActionResult> PostAsync(int providerId, [FromBody] SaveCardResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var Card = _mapper.Map<SaveCardResource, Card>(resource);
            var result = await _cardService.SaveByServicesProviderIdAsync(providerId, Card);

            if (!result.Success)
                return BadRequest(result.Message);
            var CardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(CardResource);
        }

    }
}