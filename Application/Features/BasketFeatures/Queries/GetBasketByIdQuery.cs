using Domain.Entities.Baskets;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BasketFeatures.Queries
{
    public class GetBasketByIdQuery : IRequest<Basket>
    {
        public int Id { get; set; }
        public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, Basket>
        {
            private readonly EShopDbContext _eShopDbContext;
            public GetBasketByIdQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<Basket> Handle(GetBasketByIdQuery query, CancellationToken cancellationToken)
            {
                var basket = await _eShopDbContext.Baskets
                    .FirstOrDefaultAsync(b => b.Id == query.Id);
                if (basket == null) return default;
                return basket;
            }
        }
    }
}
