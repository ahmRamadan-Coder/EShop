using Application.Features.CategoryFeatures.Commands;
using Application.Features.ProductFeatuers.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace eShopUnitTests.Tests.ProductFeatures.Command
{
    using static Testing;
    public class CreateBasketTests : TestBase
    {
        [Test]
        public async Task CreateProductCommand_ShouldReturnNewProduct()
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
            var command = new CreateProductCommand() 
            { 
                Name = "test",
                SubCategoryId = subCategoryId
            };
            // Act
            var productId =  await SendAsync(command);
            var product = await FindAsync<Product>(productId);
            //Assert
            product.Should().NotBeNull();
            product.Name.Should().Be("test");
        }
        [Test]
        public async Task CreateProductCommand_WithoutName_ShouldThrowValidationException()
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
            var command = new CreateProductCommand();
            // Act
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
            //Assert
            
        }
    }
}
