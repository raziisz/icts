using AutoMapper;
using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.InterfaceServices;
using icts_test.Entities.Entities;
using icts_test.WebAPIs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icts_test.WebAPIs.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategory _category;
        private readonly IServiceCategory _serviceCategory;

        public CategoriesController(
            IMapper mapper,
            ICategory category,
            IServiceCategory serviceCategory
        )
        {
            _mapper = mapper;
            _category = category;
            _serviceCategory = serviceCategory;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CategoryViewModel category)
        {
            var categoryMap = _mapper.Map<Category>(category);

            await _serviceCategory.Add(categoryMap);

            if (categoryMap.Notitycoes.Any()) return BadRequest(categoryMap.Notitycoes);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] CategoryViewModel category)
        {
            var categoryDB = await _category.GetEntityById(category.Id);

            if (categoryDB == null) return NotFound("Categoria inexistente.");

            var categoryMap = _mapper.Map<Category>(category);
            

            await _serviceCategory.Update(categoryMap);

            if (categoryMap.Notitycoes.Any()) return BadRequest(categoryMap.Notitycoes);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var result = await _serviceCategory.DeleteById(id);

            if (!result) return NotFound("Categoria inexistente.");

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var category = await _category.GetEntityById(id);

            if (category == null) return NotFound("Categoria inexistente.");

            var categoryMap = _mapper.Map<CategoryViewModel>(category);

            return Ok(categoryMap);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var categories = await _category.List();
            var categoriesMap = _mapper.Map<List<CategoryViewModel>>(categories);

            return Ok(categoriesMap);
        }
    }
}