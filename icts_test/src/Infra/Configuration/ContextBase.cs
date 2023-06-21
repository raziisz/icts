using icts_test.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace icts_test.Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<User>
    {
        public ContextBase(DbContextOptions<ContextBase> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GetConnectionString(), ServerVersion.AutoDetect(GetConnectionString()));
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder); 
        }
        public string GetConnectionString()
        {
            return "server=localhost;user=root;password=123456;database=cts";
        }
    }
}