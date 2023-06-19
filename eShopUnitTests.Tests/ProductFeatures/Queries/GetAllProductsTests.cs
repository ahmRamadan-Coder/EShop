using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.ProductFeatuers.Queries;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using FluentAssertions;

namespace eShopUnitTests.Tests.ProductFeatures.Queries
{
    using static Testing;
    public class GetAllProductsTests : TestBase
    {
        [Test]
        public async Task GetAllProductsQuery_ShouldReturnAllProducts()
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
            await AddAsync(new Product
            {
                Name = "Test",
                SubCategoryId = subCategoryId
            });
            var query = new GetAllProductsQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCountGreaterThan(0);
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }
        [Test]
        public async Task GetAllProductsQuery_NoProductsAdded_ShouldReturnCountEqualZero()
        {
            // Arrange
            var query = new GetAllProductsQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCount(0);

        }
    }
}
