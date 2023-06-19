using Infrastructure.DbContexts;
using MediatR;

namespace Application.Features.SubCategoryFeatures.Commands
{
    public class DeleteSubCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, int>
        {
            private EShopDbContext _eShopDbContext;
            public DeleteSubCategoryCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(DeleteSubCategoryCommand command, CancellationToken cancellationToken)
            {
                var subCategory = _eShopDbContext.SubCategories.Find(command.Id);
                if (subCategory == null) return default;
                _eShopDbContext.SubCategories.Remove(subCategory);
                await _eShopDbContext.SaveChangesAsync();
                return subCategory.Id;
            }
        }
    }
}
