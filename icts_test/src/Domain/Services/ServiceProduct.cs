using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduct;

        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }
    }
}