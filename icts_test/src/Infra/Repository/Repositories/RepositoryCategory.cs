using icts_test.Domain.Interfaces;
using icts_test.Entities.Entities;
using icts_test.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace icts_test.Infrastructure.Repository.Repositories
{
    public class RepositoryCategory : RepositoryGenerics<Category>, ICategory
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryCategory()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<bool> DeleteById(int id)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                var category = await database.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null) return false;
                
                database.Categories.Remove(category);

                return await database.SaveChangesAsync() > 0;
            }
        }
    }
}