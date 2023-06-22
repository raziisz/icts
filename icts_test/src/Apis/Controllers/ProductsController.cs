using AutoMapper;
using icts_test.Domain.Interfaces;
using icts_test.Entities.Entities;
using icts_test.WebAPIs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icts_test.WebAPIs.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduct _product;

        public ProductsController(
            IMapper mapper,
            IProduct product
        )
        {
            _mapper = mapper;
            _product = product;
        }

        [HttpPost("add")]
        public async Task<List<Notifies>> Add([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _product.Add(productMap);

            return productMap.Notifycoes;
        }

        [HttpPut("update")]
        public async Task<List<Notifies>> Update([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _product.Update(productMap);

            return productMap.Notifycoes;
        }

        [HttpDelete("delete")]
        public async Task<List<Notifies>> Delete([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _product.Delete(productMap);

            return productMap.Notifycoes;
        }

        [HttpGet("{id}")]
        public async Task<ProductViewModel> Get([FromRoute] int id)
        {
            var product = await _product.GetEntityById(id);
            var productMap = _mapper.Map<ProductViewModel>(product);

            return productMap;
        }

        [HttpGet]
        public async Task<List<ProductViewModel>> List()
        {
            var products = await _product.List();
            var productsMap = _mapper.Map<List<ProductViewModel>>(products);

            return productsMap;
        }
    }
}