

using Infrastructure.DbContexts;
using MediatR;

namespace Application.Features.SubCategoryFeatures.Commands
{
    public class UpdateSubCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, int>
        {
            private EShopDbContext _eShopDbContext;
            public UpdateSubCategoryCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(UpdateSubCategoryCommand command, CancellationToken cancellationToken)
            {
                var subCategory = _eShopDbContext.SubCategories.Find(command.Id);
                if (subCategory == null) return default;
                subCategory.Name = command.Name;
                subCategory.CategoryId = command.CategoryId;
                await _eShopDbContext.SaveChangesAsync();
                return subCategory.Id;
            }
        }
    }
}
