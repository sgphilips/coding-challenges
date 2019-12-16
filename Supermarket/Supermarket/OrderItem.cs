namespace Supermarket
{
    internal class OrderItem
    {
        internal Item Item { get; set; }
        internal int Quantity { get; set; }

        internal OrderItem(Item item)
        {
            Item = item;
            Quantity = 1;
        }
    }
}
