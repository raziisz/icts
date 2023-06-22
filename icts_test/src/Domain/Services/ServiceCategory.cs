
using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.InterfaceServices;
using icts_test.Entities.Entities;

namespace Domain.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly ICategory _ICategory;

        public ServiceCategory(ICategory ICategory)
        {
            _ICategory = ICategory;
        }

        public async Task Add(Category category)
        {
            var validateName = category.ValidatePropertyString(category.Name, "Name");

            if(validateName)
            {
                await _ICategory.Add(category);
            }

        }

        public async Task<bool> DeleteById(int id)
        {
            return await _ICategory.DeleteById(id);
        }

        public async Task Update(Category category)
        {
            var validateName = category.ValidatePropertyString(category.Name, "Name");

            if(validateName)
            {
                await _ICategory.Update(category);
            }
        }
    }
}