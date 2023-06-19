using Infrastructure.DbContexts;
using Domain.Entities.Products;
using MediatR;

namespace Application.Features.ProductFeatuers.Qureies
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly EShopDbContext _eShopDbContext;
            public GetProductByIdQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _eShopDbContext.Products.FindAsync(query.Id);
                if (product == null) return default;
                return product;
            }
        }
    }
}
