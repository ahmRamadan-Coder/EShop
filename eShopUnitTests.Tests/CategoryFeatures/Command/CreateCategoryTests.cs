using Application.Features.CategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace eShopUnitTests.Tests.CategoryFeatures.Command
{
    using static Testing;
    public class CreateSubCategoryTests : TestBase
    {
        [Test]
        public async Task CreateCategoryCommand_ShouldReturnNewCategory()
        {
            // Arrange
            var command = new CreateCategoryCommand() { Name = "test"};
            // Act
            var categoryId =  await SendAsync(command);
            var category = await FindAsync<Category>(categoryId);
            //Assert
            category.Should().NotBeNull();
            category.Name.Should().Be("test");
        }
        [Test]
        public async Task CreateCategoryCommand_WithoutName_ShouldThrowValidationException()
        {
            // Arrange
            var command = new CreateCategoryCommand();
            // Act
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
            //Assert
            
        }
    }
}
