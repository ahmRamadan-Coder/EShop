using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Baskets
{
    public class Basket : BaseEntity
    {
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();
        public void AddItem(Product product, int quantity)
        {
            if (Items.All(item => item.ProductId != item.ProductId))
            {
                Items.Add(new BasketItem { Product = product, Quantity = quantity });
            }
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == product.Id);
            if (item == null) return;
                item.Quantity -= quantity;
            if (item.Quantity == 0)
                Items.Remove(item);
        }
    }
}
