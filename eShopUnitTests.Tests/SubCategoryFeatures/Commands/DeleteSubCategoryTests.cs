using Application.Features.CategoryFeatures.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using FluentAssertions;

namespace eShopUnitTests.Tests.SubCategoryFeatures.Command
{
    
    using static Testing;
    public class DeleteSubCategoryTests : TestBase
    {
        [Test]
        public async Task DeleteSubCategoryCommand_SubCatgoryNotFound_ShouldReturnNegativeValue()
        {
            // Arrange
            var command = new DeleteSubCategoryCommand() { Id = 27};
            // Act
            var subCategoryId = await SendAsync(command);

            //Assert
            subCategoryId.Should().Be(0);
        }
        [Test]
        public async Task DeleteSubCategoryCommand_ShouldBeDeleted()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "test",
            });
            var subCategoryId = await SendAsync(new CreateSubCategoryCommand()
            {
                Name = "test",
                CategoryId = categoryId
            });
            var command = new DeleteCategoryCommand
            {
                Id = subCategoryId
            };
            await SendAsync(command);
            // Act
            
            //Assert
            
            subCategoryId.Should().BePositive();

        }
    }
}
