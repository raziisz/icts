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
    }
}