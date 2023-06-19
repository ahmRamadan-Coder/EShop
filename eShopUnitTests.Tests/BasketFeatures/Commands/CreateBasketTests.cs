using Application.Features.BasketFeatures.Commands;
using Application.Features.CategoryFeatures.Commands;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Baskets;
using FluentAssertions;


namespace eShopUnitTests.Tests.BasketFeatures.Command
{
    using static Testing;
    public class CreateBasketTests : TestBase
    {
        [Test]
        public async Task CreateBaskettCommand_ShouldReturnNewBasket()
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
            var command = new CreateBasketCommand() 
            {
                BuyerId = Guid.NewGuid().ToString(),
                ProductId = productId,
                Quantity = 10
            };
            // Act
            var basketId =  await SendAsync(command);
            var basket = await FindAsync<Basket>(basketId);
            //Assert
            basket.Should().NotBeNull();
        }
    }
}
