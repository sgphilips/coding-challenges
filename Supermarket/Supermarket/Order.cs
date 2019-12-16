using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class Order : ICheckout
    {
        private int TotalPrice { get; set; }
        private Store Store { get; }
        private List<OrderItem> OrderItems { get; }

        public Order(Store store)
        {
            Store = store;
            TotalPrice = 0;
            OrderItems = new List<OrderItem>();
        }

        public void Scan(string item)
        {
            var orderItem = Store.Items.SingleOrDefault(x => x.Sku == item);
            if (orderItem != null)
            {
                AddOrderItem(orderItem);
                TotalPrice += orderItem.UnitPrice;
            }
        }

        private void AddOrderItem(Item item)
        {
            var orderItem = OrderItems.SingleOrDefault(x => x.Item == item);
            if (orderItem == null)
            {
                OrderItems.Add(new OrderItem(item));
            }
            else
            {
                orderItem.Quantity++;
            }
        }

        public int GetTotalPrice()
        {
            ApplyDiscount();
            return TotalPrice;
        }

        private void ApplyDiscount()
        {
            foreach (var orderItem in OrderItems)
            {
                var item = orderItem.Item;
                if (Equals(item.Discount, Discount.None))
                {
                    continue;
                }

                var storeItem = Store.Items.Single(x => x.Sku == item.Sku);

                var discountQuantity = storeItem.Discount.Quantity;
                var discountAmount = storeItem.Discount.Amount;
                var numberOfDiscounts = orderItem.Quantity / discountQuantity;
                TotalPrice -= discountAmount * numberOfDiscounts;
            }
        }
    }
}
