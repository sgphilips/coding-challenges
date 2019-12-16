using System.Collections.Generic;

namespace Supermarket
{
    public class Store
    {
        public List<Item> Items { get; internal set; }

        public Store(List<Item> items)
        {
            Items = items;
        }
    }
}
