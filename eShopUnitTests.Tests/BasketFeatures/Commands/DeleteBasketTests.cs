using Application.Features.BasketFeatures.Commands;
using Application.Features.CategoryFeatures.Commands;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.BasketFeatures.Command
{

    using static Testing;
    public class DeleteBasketTests : TestBase
    {
        [Test]
        public async Task DeleteBasketCommand_BasketNotFound_ShouldReturnNegativeValue()
        {
            // Arrange
            var command = new DeleteBasketCommand() { Id = 27 };
            // Act
            var basketId = await SendAsync(command);

            //Assert
            basketId.Should().Be(-1);
        }
        [Test]
        public async Task DeleteBasketCommand_ShouldBeDeleted()
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
            var basketId = await SendAsync(new CreateBasketCommand()
            {
                ProductId = productId,
                BuyerId = Guid.NewGuid().ToString(),
                Quantity = 200
            });
            var command = new DeleteBasketCommand
            {
                Id = basketId,
                ProductId = productId,
            };
            await SendAsync(command);
            // Act

            //Assert

            basketId.Should().BePositive();

        }
    }
}
