using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Categories
{
    public class SubCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
