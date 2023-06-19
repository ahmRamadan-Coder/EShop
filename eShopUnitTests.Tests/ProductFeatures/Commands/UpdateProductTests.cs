using Application.Features.CategoryFeatures.Commands;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using FluentAssertions;

namespace eShopUnitTests.Tests.ProductFeatures.Command
{
    using static Testing;
    public class UpdateProductTests : TestBase
    { 
        [Test]
        public async Task UpdateProductCommand_ProductNotFound_ShouldReturnZeroValue()
        {
            // Arrange
            var command = new UpdateProductCommand() { Id = 27, Name = "test" };
            // Act
            var productId = await SendAsync(command);

            //Assert
            productId.Should().Be(0);
        }
        [Test]
        public async Task UpdateProductCommand_ShouldBeUpdated()
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
            var command = new UpdateProductCommand 
            {
                Id = productId,
                Name = "UpdateTest"
            };
            await SendAsync(command);
            // Act
            var product = await FindAsync<Product>(productId);
            //Assert
            product.Should().NotBeNull();
            product.Name.Should().Be("UpdateTest");

        }
    }
}
