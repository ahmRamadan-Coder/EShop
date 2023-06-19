using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.SubCategoryFeatures.Commands;
using Application.Features.SubCategoryFeatures.Queries;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.SubCategoryFeatures.Queries
{
    using static Testing;
    public class GetSubCategoryByIdTests
    {
        [Test]
        public async Task GetSubCategoriesByIdQuery_ShouldReturnSubCategory()
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
            var query = new GetSubCategoryByIdQuery
            {
                Id = subCategoryId,
            };
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Name.Should().Be("test");
            result.Should().NotBeNull();
        }
        [Test]
        public async Task GetSubCategoryByIdQuery_NotFound_ShouldReturnCountEqualNegative()
        {
            // Arrange
            
            var query = new GetSubCategoryByIdQuery
            {
                Id = 50,
            };
            // Act
            var result = await SendAsync(query);
            // Assert
            
            result.Should().BeNull();

        }
    }
}
