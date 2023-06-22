using icts_test.Entities.Entities;

namespace icts_test.Domain.Interfaces.InterfaceServices
{
    public interface IServiceCategory
    {
        Task Add(Category category);
        Task Update(Category category);
        Task<bool> DeleteById(int id);
    }
}