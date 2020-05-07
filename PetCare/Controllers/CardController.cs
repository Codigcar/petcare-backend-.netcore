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
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _CardService;
        private readonly IMapper _mapper;

        public CardController(ICardService CardService, IMapper mapper)
        {
            _CardService = CardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CardResource>> GetAllAsync()
        {

            var customers = await _CardService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Card>, IEnumerable<CardResource>>(customers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveCardResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var Card = _mapper.Map<SaveCardResource, Card>(resource);
            var result = await _CardService.SaveAsync(Card);
            if (!result.Success)
                return BadRequest(result.Message);
            var CardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(CardResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCardResource resource)
        {
            var Card = _mapper.Map<SaveCardResource, Card>(resource);
            var result = await _CardService.UpdateAsync(id, Card);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var CardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(CardResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _CardService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(categoryResource);
        }
    }
}