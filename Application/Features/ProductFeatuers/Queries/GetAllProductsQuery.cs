using Infrastructure.DbContexts;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatuers.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly EShopDbContext _eShopDbContext;
            public GetAllProductsQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _eShopDbContext.Products.ToListAsync();
                if (productList == null) return default;
                return productList.AsReadOnly();
            }
        }
    }
}
