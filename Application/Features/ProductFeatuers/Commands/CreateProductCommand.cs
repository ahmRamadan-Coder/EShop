using Domain.Entities.Categories;
using Domain.Entities.Products;
using MediatR;
using Infrastructure.DbContexts;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.ProductFeatuers.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public int QuantityInStock { get; set; }
        public int Rate { get; set; }
        public int SubCategoryId { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly EShopDbContext _eShopContext;
            public CreateProductCommandHandler(EShopDbContext eShopContext)
            {
                _eShopContext = eShopContext;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                    PhotoUrl = command.PhotoUrl,
                    QuantityInStock = command.QuantityInStock,
                    Rate = command.Rate,
                    SubCategoryId = command.SubCategoryId
                };
                if (product.Name == null) throw new ValidationException();
                _eShopContext.Products.Add(product);
                await _eShopContext.SaveChangesAsync();
                return product.Id;
            }
        }
    }


}
