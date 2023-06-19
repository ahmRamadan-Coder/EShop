using Application.Features.CategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.CategoryFeatures.Command
{
    using static Testing;
    public class UpdateSubCategoryTests : TestBase
    { 
        [Test]
        public async Task UpdateCategoryCommand_CatgoryNotFound_ShouldReturnNegativeValue()
        {
            // Arrange
            var command = new UpdateCategoryCommand() { Id = 27, Name = "test" };
            // Act
            var categoryId = await SendAsync(command);
            
            //Assert
            categoryId.Should().BeNegative();
        }
        [Test]
        public async Task UpdateCategoryCommand_ShouldBeUpdated()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand() 
            {
                Name = "test",
            });
            var command = new UpdateCategoryCommand 
            {
                Id = categoryId,
                Name = "UpdateTest"
            };
            await SendAsync(command);
            // Act
            var category = await FindAsync<Category>(categoryId);
            //Assert
            category.Should().NotBeNull();
            category.Name.Should().Be("UpdateTest");

        }
    }
}
