using icts_test.Entities.Entities;

namespace icts_test.Domain.Interfaces.InterfaceServices
{
    public interface IServiceProduct
    {
        
        Task Add(Product product);
        Task Update(Product product);
        Task<bool> DeleteById(int id);
    }
}