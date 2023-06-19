using Application.Features.CategoryFeatures.Commands;
using Application.Features.SubCategoryFeatures.Commands;
using Domain.Entities.Categories;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace eShopUnitTests.Tests.SubCategoryFeatures.Command
{
    using static Testing;
    public class UpdateSubCategoryTests : TestBase
    { 
        [Test]
        public async Task UpdateSubCategoryCommand_SubCatgoryNotFound_ShouldReturnNegativeValue()
        {
            // Arrange
            var command = new UpdateSubCategoryCommand() { Id = 27, Name = "test" };
            // Act
            var subCategoryId = await SendAsync(command);
            
            //Assert
            subCategoryId.Should().Be(0);
        }
        [Test]
        public async Task UpdateSubCategoryCommand_ShouldBeUpdated()
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
            var command = new UpdateSubCategoryCommand 
            {
                Id = subCategoryId,
                Name = "UpdateTest",
                CategoryId = categoryId
            };
            await SendAsync(command);
            // Act
            var subCategory = await FindAsync<SubCategory>(subCategoryId);
            //Assert
            subCategory.Should().NotBeNull();
            subCategory.Name.Should().Be("UpdateTest");

        }
    }
}
