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
        private readonly ICategory _category;

        public ProductsController(
            IMapper mapper,
            IProduct product,
            IServiceProduct serviceProduct,
            ICategory category
        )
        {
            _mapper = mapper;
            _product = product;
            _serviceProduct = serviceProduct;
            _category = category;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] ProductViewModel product)
        {
            var productMap = _mapper.Map<Product>(product);

            await _serviceProduct.Add(productMap);

            if(productMap.Notitycoes.Any()) return BadRequest(productMap.Notitycoes);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] ProductViewModel product)
        {
            var productDb = await _product.GetEntityById(product.Id);
            if (productDb == null) return NotFound("Produto inexistente.");
            
            var productMap = _mapper.Map<Product>(product);

            await _serviceProduct.Update(productMap);

            if(productMap.Notitycoes.Any()) return BadRequest(productMap.Notitycoes);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _serviceProduct.DeleteById(id);
            
            if (!result) return NotFound("Produto inexistente para exclusão.");

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var product = await _product.GetEntityById(id);
            if (product == null) return NotFound("Produto inexistente.");

            var productMap = _mapper.Map<ProductViewModel>(product);

            return Ok(productMap);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var products = await _product.List();
            var productsMap = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsMap);
        }
    }
}