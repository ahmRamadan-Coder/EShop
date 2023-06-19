
using Infrastructure.DbContexts;
using MediatR;

namespace Application.Features.ProductFeatuers.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly EShopDbContext _eShopDbContext;
            public DeleteProductByIdCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = _eShopDbContext.Products.Find(command.Id);
                if (product == null) return default;

                _eShopDbContext.Products.Remove(product);
                _eShopDbContext.SaveChanges();
                return product.Id;
            }
        }
    }

}