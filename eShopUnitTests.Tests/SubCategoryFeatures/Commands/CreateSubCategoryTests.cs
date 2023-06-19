using Application.Features.CategoryFeatures.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace eShopUnitTests.Tests.SubCategoryFeatures.Command
{
    using static Testing;
    public class CreateSubCategoryTests : TestBase
    {
        [Test]
        public async Task CreateSubCategoryCommand_ShouldReturnNewSubCategory()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "test",
            });
            var command = new CreateSubCategoryCommand() { Name = "test",CategoryId = categoryId};
            // Act
            var subCategoryId =  await SendAsync(command);
            var SubCategory = await FindAsync<SubCategory>(subCategoryId);
            //Assert
            SubCategory.Should().NotBeNull();
            SubCategory.Name.Should().Be("test");
        }
        [Test]
        public async Task CreateSubCategoryCommand_WithoutName_ShouldThrowValidationException()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "test",
            });
            var command = new CreateSubCategoryCommand() { CategoryId = categoryId};
            // Act
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
            //Assert
            
        }
    }
}
