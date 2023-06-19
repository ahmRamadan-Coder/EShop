using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.SubCategoryFeatures.Queries;
using Domain.Entities.Categories;
using FluentAssertions;

namespace eShopUnitTests.Tests.SubCategoryFeatures.Queries
{
    using static Testing;
    public class GetAllSubCategoriesTests : TestBase
    {
        [Test]
        public async Task GetAllSubCategoriesQuery_ShouldReturnAllSubCategories()
        {
            // Arrange
            var categoryId = await SendAsync(new CreateCategoryCommand()
            {
                Name = "test",
            });
            await AddAsync(new SubCategory
            {
                Name = "Test",
                CategoryId = categoryId
            });
            var query = new GetAllSubCategoriesQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCountGreaterThan(0);
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }
        [Test]
        public async Task GetAllSubCategoriesQuery_NoSubCatgeoriesAdded_ShouldReturnCountEqualZero()
        {
            // Arrange
            var query = new GetAllSubCategoriesQuery();
            // Act
            var result = await SendAsync(query);
            // Assert
            result.Should().HaveCount(0);

        }
    }
}
