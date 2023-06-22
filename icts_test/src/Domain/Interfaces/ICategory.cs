using icts_test.Domain.Interfaces.Generics;
using icts_test.Entities.Entities;

namespace icts_test.Domain.Interfaces
{
    public interface ICategory : IGenerics<Category>
    {
        public Task<bool> DeleteById(int id);
    }
}