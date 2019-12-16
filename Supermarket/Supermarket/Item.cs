using System;

namespace Supermarket
{
    public class Item
    {
        internal string Sku { get; }
        public int UnitPrice { get; private set; }
        public Discount Discount { get; private set; }

        public Item(string sku, int unitPrice)
        {
            if (unitPrice < 0)
            {
                throw new ArgumentException("Can't create a item with a negative unit price");
            }

            Sku = sku;
            UnitPrice = unitPrice;
            Discount = Discount.None;
        }

        public Item(string sku, int unitPrice, int discountQuantity, int discountPrice)
        {
            if (unitPrice < 0)
            {
                throw new ArgumentException("Can't create a item with a negative unit price");
            }

            Sku = sku;
            UnitPrice = unitPrice;
            Discount = new Discount(discountQuantity, unitPrice, discountPrice);
        }

        public void UpdateUnitPrice(int unitPrice)
        {
            if (unitPrice < 0)
            {
                throw new ArgumentException("Can't update the item with a negative unit price");
            }

            UnitPrice = unitPrice;
        }

        public void UpdateDiscount(int discountQuantity, int discountPrice)
        {
            Discount = new Discount(discountQuantity, UnitPrice, discountPrice);
        }
    }
}
