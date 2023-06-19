using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.EntitiesConfigurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(id => id.Id);
            builder.Property(n => n.Name).HasMaxLength(250).IsRequired(false);
            builder.Property(d => d.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Price).HasColumnType("decimal");
            builder.Property(ph => ph.PhotoUrl).HasMaxLength(500).IsRequired(false);
            builder.Property(r => r.Rate).HasColumnType("int");            
            builder.Property(q => q.QuantityInStock).HasColumnType("int");  
            builder.HasOne(x => x.SubCategory)
                .WithMany(x => x.Products).HasForeignKey(x => x.SubCategoryId);
        }
    }
}
