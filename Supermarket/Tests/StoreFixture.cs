using System;
using System.Collections.Generic;
using Supermarket;

namespace Tests
{
    public class StoreFixture : IDisposable
    {
        public Store Store { get; }

        public StoreFixture()
        {
            var itemA = new Item("A", 50, 3, 130);
            var itemB = new Item("B", 30, 2, 45);
            var itemC = new Item("C", 20);
            var itemD = new Item("D", 15);

            var items = new List<Item> { itemA, itemB, itemC, itemD };

            Store = new Store(items);
        }

        public void Dispose()
        {
        }
    }
}
