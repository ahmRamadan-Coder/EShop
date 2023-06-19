using Application.Features.CategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.CategoryFeatures.Command
{
    
    using static Testing;
    public class DeleteSubCategoryTests : TestBase
    {
        [Test]
        public async Task DeleteCategoryCommand_CatgoryNotFound_ShouldReturnNegativeValue()
        {
            // Arrange
            var command = new DeleteCategoryCommand() { Id = 27};
            // Act
            var categoryId = await SendAsync(command);

            //Assert
            categoryId.Should().BeNegative();
        }
        [Test]
        public async Task DeleteCategoryCommand_ShouldBeDeleted()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "test",
            });
            var command = new DeleteCategoryCommand
            {
                Id = categoryId
            };
            await SendAsync(command);
            // Act
            
            //Assert
            
            categoryId.Should().BePositive();

        }
    }
}
