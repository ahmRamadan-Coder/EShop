using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.SubCategoryFeatures.Commands
{
    public class CreateSubCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, int>
        {
            private EShopDbContext _eShopDbContext;
            public CreateSubCategoryCommandHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<int> Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
            {
                var subCategory = new SubCategory
                {
                    Name = command.Name,
                    CategoryId = command.CategoryId,
                };
                if (subCategory.Name == null) throw new ValidationException();
                _eShopDbContext.Add(subCategory);
                await _eShopDbContext.SaveChangesAsync();
                return subCategory.Id;
            }
        }
    }
}
