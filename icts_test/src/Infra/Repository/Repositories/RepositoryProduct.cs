using icts_test.Domain.Interfaces;
using icts_test.Entities.Entities;
using icts_test.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace icts_test.Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Product>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryProduct()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyExistsCategory(int categoryId)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                var category = await database.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
                return category != null;
            }
        }
    }
}