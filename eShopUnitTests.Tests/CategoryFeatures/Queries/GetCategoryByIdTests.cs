using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.CategoryFeatures.Queries
{
    using static Testing;
    public class GetSubCategoryByIdTests
    {
        [Test]
        public async Task GetCategoriesByIdQuery_ShouldReturnCategory()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "test",
            });
            var query = new GetCategoryByIdQuery
            {
                Id = categoryId,
            };
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Name.Should().Be("test");
            result.Should().NotBeNull();
        }
        [Test]
        public async Task GetCategoryByIdQuery_NotFound_ShouldReturnCountEqualNegative()
        {
            // Arrange
            
            var query = new GetCategoryByIdQuery
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
