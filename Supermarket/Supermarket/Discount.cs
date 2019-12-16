using System;

namespace Supermarket
{
    public struct Discount
    {
        public static readonly Discount None = new Discount
        {
            Quantity = -1,
            Amount = -1
        };
        public int Quantity { get; private set; } 
        public int Amount { get; private set; }

        internal Discount(int quantity, int price, int discountPrice)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Discount quantity must be greater than zero");
            }
            if (discountPrice <= 0)
            {
                throw new ArgumentException("Discount price must be greater than zero");
            }

            Quantity = quantity;
            Amount = quantity * price - discountPrice;
        }
    }
}
