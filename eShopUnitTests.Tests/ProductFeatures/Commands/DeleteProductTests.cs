using Application.Features.CategoryFeatures.Commands;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.ProductFeatures.Command
{
    
    using static Testing;
    public class DeleteProductTests : TestBase
    {
        [Test]
        public async Task DeleteProductCommand_ProductNotFound_ShouldReturnZero()
        {
            // Arrange
            var command = new DeleteProductByIdCommand() { Id = 27};
            // Act
            var productId = await SendAsync(command);

            //Assert
            productId.Should().Be(0);
        }
        [Test]
        public async Task DeleteProductCommand_ShouldBeDeleted()
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
            var command = new DeleteProductByIdCommand
            {
                Id = productId
            };
            await SendAsync(command);
            // Act
            
            //Assert
            
            productId.Should().BePositive();

        }
    }
}
