using Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.EntitiesConfigurations.SubCategoryConfigurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(id => id.Id);
            builder.Property(name => name.Name).HasMaxLength(250).IsRequired(false);
            builder.HasOne(g => g.Category)
                .WithMany(s => s.SubCategories).HasForeignKey(g => g.CategoryId).IsRequired();
        }
    }
}
