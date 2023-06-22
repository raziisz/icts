using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.InterfaceServices;
using icts_test.Entities.Entities;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduct;

        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        public async Task Add(Product product)
        {
            bool[] validations = {
                product.ValidatePropertyString(product.Name, "Name"),
                product.ValidatePropertyString(product.Description, "Description"),
                product.ValidatePropertyDouble(product.Price, "Price"),
                product.ValidatePropertyInt(product.CategoryId, "CategoryId"),
            };

            var listValidations = new List<bool>(validations);
            

            if (listValidations.TrueForAll(x => x == true))
            {
                var categoryExists = await ExistsCategory(product.CategoryId);
                if (!categoryExists) 
                {
                    product.AddNotifies("Categoria inexistente.", "CategoryId");
                    return;
                }
                
                await _IProduct.Add(product);

            }
        }

        public async Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product product)
        {
            bool[] validations = {
                product.ValidatePropertyInt(product.Id, "Id"),
                product.ValidatePropertyString(product.Name, "Name"),
                product.ValidatePropertyString(product.Description, "Description"),
                product.ValidatePropertyDouble(product.Price, "Price"),
                product.ValidatePropertyInt(product.CategoryId, "CategoryId"),
            };

            var listValidations = new List<bool>(validations);
            

            if (listValidations.TrueForAll(x => x == true))
            {
                await _IProduct.Update(product);
            }
        }

        private async Task<bool> ExistsCategory(int categoryId)
        {
            return await _IProduct.VerifyExistsCategory(categoryId);
        }
    }
}