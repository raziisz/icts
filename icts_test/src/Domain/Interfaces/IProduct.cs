using icts_test.Domain.Interfaces.Generics;
using icts_test.Entities.Entities;

namespace icts_test.Domain.Interfaces
{
    public interface IProduct : IGenerics<Product>
    {
        public Task<bool> DeleteById(int id);
        public Task<bool> VerifyExistsCategory(int categoryId);
    }
}