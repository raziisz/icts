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
        public async Task<List<Notifies>> Add([FromBody] CategoryViewModel category)
        {
            var categoryMap = _mapper.Map<Category>(category);

            await _serviceCategory.Add(categoryMap);

            return categoryMap.Notitycoes;
        }

        [HttpPut("update")]
        public async Task<List<Notifies>> Update([FromBody] CategoryViewModel category)
        {
            var categoryMap = _mapper.Map<Category>(category);

            await _serviceCategory.Update(categoryMap);

            return categoryMap.Notitycoes;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var result = await _serviceCategory.DeleteById(id);

            if (!result) return BadRequest("Categoria inexistente.");

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CategoryViewModel> Get([FromRoute] int id)
        {
            var category = await _category.GetEntityById(id);
            var categoryMap = _mapper.Map<CategoryViewModel>(category);

            return categoryMap;
        }

        [HttpGet]
        public async Task<List<CategoryViewModel>> List()
        {
            var categories = await _category.List();
            var categoriesMap = _mapper.Map<List<CategoryViewModel>>(categories);

            return categoriesMap;
        }
    }
}