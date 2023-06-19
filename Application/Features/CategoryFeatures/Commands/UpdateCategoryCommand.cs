

using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;

namespace Application.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
        {
            private readonly EShopDbContext _eShopDbContext;
            public UpdateCategoryCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
            {
                var category = _eShopDbContext.Find<Category>(command.Id);
                if (category == null) return -1;
                category.Name = command.Name;
                await _eShopDbContext.SaveChangesAsync();
                return category.Id;
            }
        }
    }
}
