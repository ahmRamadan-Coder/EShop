using Domain.Entities.Appusers;
using Domain.Entities.Baskets;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Presistence.EntitiesConfigurations.CategoryConfigurations;
using Presistence.EntitiesConfigurations.ProductConfigurations;
using Presistence.EntitiesConfigurations.SubCategoryConfigurations;

namespace Infrastructure.DbContexts
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new SubCategoryConfiguration().Configure(modelBuilder.Entity<SubCategory>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
