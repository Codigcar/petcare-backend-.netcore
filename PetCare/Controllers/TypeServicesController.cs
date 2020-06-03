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
    [Route("api/typeproduts/{typeproductId}/products")]
    public class TypeServicesController : ControllerBase
    {
        private readonly IProductService _product;
        private readonly IMapper _mapper;

        public TypeServicesController(IProductService product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }
/*
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string name,[FromBody] SaveServiceResource saveServiceResource)
        {
            //string name = "peluqueria";
            var result = await _service.findByName(saveServiceResource.Name);
            return Ok(result);
        }
        */
        [HttpPost]
        public async Task<ActionResult> SaveServiceByTypeIdAsync(int typeproductId, [FromBody] SaveProductResource saveProductResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var entity = _mapper.Map<SaveProductResource, Product>(saveProductResource);
            var result = await _product.SaveByTypeProductIdAsync(typeproductId, entity);
            if (!result.Success)
                return BadRequest(result.Message);

            var Resource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(Resource);
        }


        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByServiceTypeIdAsync(int typeproductId)
        {
            var products = await _product.ListByTypeProductIdAsync(typeproductId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }


    }
}