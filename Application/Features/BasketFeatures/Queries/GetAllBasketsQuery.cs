using Domain.Entities.Baskets;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.BasketFeatures.Queries
{
    public class GetAllBasketsQuery : IRequest<IEnumerable<Basket>>
    {
        public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQuery, IEnumerable<Basket>>
        {
            private readonly EShopDbContext _eShopDbContext;
            public GetAllBasketsQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<IEnumerable<Basket>> Handle(GetAllBasketsQuery query, CancellationToken cancellationToken)
            {
                var baskets = await _eShopDbContext.Baskets.ToListAsync();
                if (baskets == null) return default;
                return baskets.AsReadOnly();
            }
        }
    }
}
