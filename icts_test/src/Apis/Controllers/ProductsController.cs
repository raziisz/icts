using AutoMapper;
using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.InterfaceServices;
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
        private readonly IServiceProduct _serviceProduct;

        public ProductsController(
            IMapper mapper,
            IProduct product,
            IServiceProduct serviceProduct
        )
        {
            _mapper = mapper;
            _product = product;
            _serviceProduct = serviceProduct;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _serviceProduct.Add(productMap);

            if(productMap.Notitycoes.Any()) return BadRequest(productMap.Notitycoes);

            return NoContent();
        }

        [HttpPut("update")]
        public async Task<List<Notifies>> Update([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _serviceProduct.Update(productMap);

            return productMap.Notitycoes;
        }

        [HttpDelete("delete")]
        public async Task<List<Notifies>> Delete([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _product.Delete(productMap);

            return productMap.Notitycoes;
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