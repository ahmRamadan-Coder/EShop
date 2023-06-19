using Domain.Entities.Baskets;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.BasketFeatures.Commands
{
    public class CreateBasketCommand : IRequest<int>
    {
        public string BuyerId { get; set; } 
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, int>
        {
            private readonly EShopDbContext _eShopDbContext;
            public CreateBasketCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }

            public async Task<int> Handle(CreateBasketCommand command, CancellationToken cancellationToken)
            {
                var basket = await _eShopDbContext.Baskets
                    .Include(i => i.Items)
                    .ThenInclude(p => p.Product)
                    .FirstOrDefaultAsync(x => x.BuyerId == command.BuyerId);
                if (basket == null)
                {
                    basket = new Basket { BuyerId = Guid.NewGuid().ToString() };
                    _eShopDbContext.Baskets.Add(basket);
                }
                var product = await _eShopDbContext.Products.FindAsync(command.ProductId);
                if (product != null)
                    basket.AddItem(product, command.Quantity);
                await _eShopDbContext.SaveChangesAsync();
                return basket.Id;
            }
        }
    }
}
