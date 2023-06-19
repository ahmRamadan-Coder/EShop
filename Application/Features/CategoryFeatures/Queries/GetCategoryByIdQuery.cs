using Domain.Entities.Categories;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Queries
{
    public class GetCategoryByIdQuery:IRequest<Category>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
        {
            private readonly EShopDbContext _eShopDbContext;
            public GetCategoryByIdQueryHandler(EShopDbContext eShopDbContext)
            {
                _eShopDbContext = eShopDbContext;
            }
            public async Task<Category> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var category = await _eShopDbContext.Categories.FindAsync(query.Id);
                if (category == null) return default;
                return category;
            }
        }
    }
}
