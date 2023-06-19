using Domain.Common;
using Domain.Entities.Categories;

namespace Domain.Entities.Products
{
    public class Product:BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public int QuantityInStock { get; set; }
        public int Rate { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
