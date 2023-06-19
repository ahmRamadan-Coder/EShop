using Application.Features.BasketFeatures.Queries;
using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.ProductFeatuers.Queries;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Baskets;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using FluentAssertions;

namespace eShopUnitTests.Tests.BasketFeatures.Queries
{
    using static Testing;
    public class GetAllBasketsTests : TestBase
    {
        [Test]
        public async Task GetAllBasketsQuery_ShouldReturnAllBaskets()
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
                Name = "testProduct",
                SubCategoryId = subCategoryId
            });
            await AddAsync(new Basket
            {
                Name = "Test",
                BuyerId = Guid.NewGuid().ToString(),
            });
            var query = new GetAllBasketsQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCountGreaterThan(0);
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }
        [Test]
        public async Task GetAllBasketsQuery_NoBasketsAdded_ShouldReturnCountEqualZero()
        {
            // Arrange
            var query = new GetAllBasketsQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCount(0);

        }
    }
}
