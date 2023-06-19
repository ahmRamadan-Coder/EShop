using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly EShopDbContext _eShopDbContext;
        public CreateCategoryCommandHandler(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }
        public async Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = command.Name
            };
            if (category.Name == null)throw new ValidationException();
            _eShopDbContext.Categories.Add(category);
            await _eShopDbContext.SaveChangesAsync();
            return category.Id;
        }
    }
}
