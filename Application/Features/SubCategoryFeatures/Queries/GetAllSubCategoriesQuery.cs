using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SubCategoryFeatures.Queries
{
    public class GetAllSubCategoriesQuery : IRequest<IEnumerable<SubCategory>>
    {
        public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, IEnumerable<SubCategory>>
        {
            private EShopDbContext _eShopDbContext;
            public GetAllSubCategoriesQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<IEnumerable<SubCategory>> Handle(GetAllSubCategoriesQuery query, CancellationToken cancellationToken)
            {
                var subGategories = await _eShopDbContext.SubCategories.ToListAsync();
                if (subGategories == null) return default;
                return subGategories.AsReadOnly();
            }
        }
    }
}
