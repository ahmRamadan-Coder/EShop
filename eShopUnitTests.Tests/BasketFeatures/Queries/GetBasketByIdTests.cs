using Application.Features.BasketFeatures.Commands;
using Application.Features.BasketFeatures.Queries;
using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.ProductFeatuers.Qureies;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Baskets;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.BasketFeatures.Queries
{
    using static Testing;
    public class GetBasketByIdTests
    {
        [Test]
        public async Task GetBasketByIdQuery_ShouldReturnBasket()
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
            var basketId = await SendAsync(new CreateBasketCommand()
            {
                BuyerId = Guid.NewGuid().ToString(),
                ProductId = productId
            });
            
            var query = new GetBasketByIdQuery
            {
                Id = basketId
            };
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Id.Should().BeGreaterThan(0);
            result.Should().NotBeNull();
        }
        [Test]
        public async Task GetBasketByIdQuery_NotFound_ShouldBeNull()
        {
            // Arrange
            
            var query = new GetBasketByIdQuery
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
