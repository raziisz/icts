using AutoMapper;
using icts_test.Domain.Interfaces;
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

        public CategoriesController(
            IMapper mapper,
            ICategory category
        )
        {
            _mapper = mapper;
            _category = category;
        }

        [HttpPost("add")]
        public async Task<List<Notifies>> Add([FromBody] CategoryViewModel category)
        {
            var categoryMap = _mapper.Map<Category>(category);

            await _category.Add(categoryMap);

            return categoryMap.Notifycoes;
        }

        [HttpPut("update")]
        public async Task<List<Notifies>> Update([FromBody] CategoryViewModel category)
        {
            var categoryMap = _mapper.Map<Category>(category);

            await _category.Update(categoryMap);

            return categoryMap.Notifycoes;
        }

        [HttpDelete("delete")]
        public async Task<List<Notifies>> Delete([FromBody] CategoryViewModel category)
        {
            var categoryMap = _mapper.Map<Category>(category);

            await _category.Delete(categoryMap);

            return categoryMap.Notifycoes;
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