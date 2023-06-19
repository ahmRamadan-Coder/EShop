using Application.Features.CategoryFeatures.Queries;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.CategoryFeatures.Queries
{
    using static Testing;
    public class GetAllSubCategoriesTests : TestBase
    {
        [Test]
        public async Task GetAllCategoriesQuery_ShouldReturnAllCategories()
        {
            // Arrange
            await AddAsync(new Category
            {
                Name = "Test",
            });
            var query = new GetAllCategoriesQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCountGreaterThan(0);
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }
        [Test]
        public async Task GetAllCategoriesQuery_NoCatgeoriesAdded_ShouldReturnCountEqualZero()
        {
            // Arrange
            var query = new GetAllCategoriesQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCount(0);

        }
    }
}
