

using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;

namespace Application.Features.SubCategoryFeatures.Queries
{
    public class GetSubCategoryByIdQuery : IRequest<SubCategory>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, SubCategory>
        {
            private EShopDbContext _eShopDbContext;
            public GetCategoryByIdQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<SubCategory> Handle(GetSubCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var subCategory = await _eShopDbContext.SubCategories.FindAsync(query.Id);
                if (subCategory == null) return default;
                return subCategory;
            }
        }
    }
}
