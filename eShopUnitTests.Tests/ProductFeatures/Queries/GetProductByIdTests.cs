using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.ProductFeatuers.Qureies;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.ProductFeatures.Queries
{
    using static Testing;
    public class GetProductByIdTests
    {
        [Test]
        public async Task GetProductsByIdQuery_ShouldReturnProduct()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "testCategory",
            });
            var subCategoryId = await SendAsync(new CreateSubCategoryCommand()
            {
                Name = "testSubCategory",
                CategoryId = categoryId
            });
            var productId = await SendAsync(new CreateProductCommand()
            {
                Name = "test",
                SubCategoryId = subCategoryId
            });
            var query = new GetProductByIdQuery
            {
                Id = productId,
            };
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Name.Should().Be("test");
            result.Should().NotBeNull();
        }
        [Test]
        public async Task GetProductByIdQuery_NotFound_ShouldReturnCountEqualNegative()
        {
            // Arrange
            
            var query = new GetProductByIdQuery
            {
                Id = 50,
            };
            // Act
            var result = await SendAsync(query);
            // Assert
            
            result.Should().BeNull();

        }
    }
}
