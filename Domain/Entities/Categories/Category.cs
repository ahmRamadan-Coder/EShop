using Domain.Common;

namespace Domain.Entities.Categories
{
    public class Category : BaseEntity
    {
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
