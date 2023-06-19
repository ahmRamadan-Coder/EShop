
using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CategoryFeatures.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
        {
            EShopDbContext _eShopDbContext;
            public GetAllCategoriesQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = await _eShopDbContext.Categories.ToListAsync();
                if (categories == null) return default;
                return categories.AsReadOnly();
            }
        }
    }
}
