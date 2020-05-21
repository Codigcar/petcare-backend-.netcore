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
    public class ProviderPaymentController : ControllerBase
    {
        private readonly IPaymentService _PaymentService;
        private readonly IMapper _mapper;

        public ProviderPaymentController(IPaymentService PaymentService, IMapper mapper)
        {
            _PaymentService = PaymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetListByCustomerIdAsync(int sproviderId)
        {

            var customers = await _PaymentService.ListByServicesProviderIdAsync(sproviderId);
            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(customers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int providerId, [FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var Payment = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _PaymentService.SaveByServicesProviderIdAsync(providerId, Payment);

            if (!result.Success)
                return BadRequest(result.Message);
            var PaymentResource = _mapper.Map<Payment, PaymentResource>(result.payment);
            return Ok(PaymentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
        {
            var customer = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _PaymentService.UpdateAsync(id, customer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<Payment, PaymentResource>(result.payment);
            return Ok(customerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _PaymentService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Payment, PaymentResource>(result.payment);
            return Ok(categoryResource);
        }



    }
}
