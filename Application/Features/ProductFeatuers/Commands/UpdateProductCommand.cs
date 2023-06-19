
using Infrastructure.DbContexts;
using MediatR;

namespace Application.Features.ProductFeatuers.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public int QuantityInStock { get; set; }
        public int Rate { get; set; }
        public int SubCategoryId { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly EShopDbContext _eShopDbContext;
            public UpdateProductCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _eShopDbContext.Products.Find(command.Id);
                if (product == null) return default;
                product.Name = command.Name;
                product.Price = command.Price;
                product.Rate = command.Rate;
                await _eShopDbContext.SaveChangesAsync();
                return product.Id;
            }
        }
    }

}
