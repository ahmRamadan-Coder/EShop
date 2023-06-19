

using Infrastructure.DbContexts;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.CategoryFeatures.Commands
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
        {
            private readonly EShopDbContext _eShopDbContext;
            public DeleteCategoryCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
            {
                var category = _eShopDbContext.Categories.Find(command.Id);
                if (category == null) return -1;
                _eShopDbContext.Categories.Remove(category);
                await _eShopDbContext.SaveChangesAsync();
                return category.Id;
            }
            
        }
    }
}

