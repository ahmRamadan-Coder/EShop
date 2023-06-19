using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BasketFeatures.Commands
{
    public class DeleteBasketCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, int>
        {
            private readonly EShopDbContext _eShopDbContext;
            public DeleteBasketCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
            {
                var basket = await _eShopDbContext.Baskets
                   .Include(i => i.Items)
                   .ThenInclude(p => p.Product)
                   .FirstOrDefaultAsync(x => x.Id == command.Id);
                if (basket == null) return -1;
                if (basket.Items.Count == 0)
                {
                    _eShopDbContext.Baskets.Remove(basket);
                }
                var product = await _eShopDbContext.Products.FindAsync(command.ProductId);
                basket.RemoveItem(product, command.Quantity);
                _eShopDbContext.Remove(basket);
                await _eShopDbContext.SaveChangesAsync();
                return basket.Id;
            }
        }
    }
}
