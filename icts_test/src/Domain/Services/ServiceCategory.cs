
using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly ICategory _ICategory;

        public ServiceCategory(ICategory ICategory)
        {
            _ICategory = ICategory;
        }
    }
}