using Supermarket;
using Xunit;

namespace Tests
{
    public class OrderTests : IClassFixture<StoreFixture>
    {
        private readonly Store _store;

        public OrderTests(StoreFixture storeFixture)
        {
            _store = storeFixture.Store;
        }

        [Fact]
        public void ShouldUpdateTotalPriceWhenAddingOrderItem()
        {
            var order = new Order(_store);
            order.Scan("C");

            Assert.Equal(20, order.GetTotalPrice());
        }

        [Fact]
        public void ShouldNotUpdateTotalPriceWhenAddingOrderItemThatDoesNotExistInStore()
        {
            var order = new Order(_store);
            order.Scan("X");

            Assert.Equal(0, order.GetTotalPrice());
        }

        [Theory]
        [InlineData(160, "A", "B", "A", "A")]       // discount applied once with random scanning order
        [InlineData(90, "B", "B", "B", "B")]        // discount applied twice on the same item
        [InlineData(180, "A", "A", "A", "A")]       // discount applied once 
        [InlineData(175, "B", "B", "A", "A", "A")]  // discount applied twice on two different items
        public void ShouldApplyDiscountWhenTriggeringSpecialOffer(int expectedTotalPrice, params string[] items)
        {
            var order = new Order(_store);
            foreach (var item in items)
            {
                order.Scan(item);
            }

            Assert.Equal(expectedTotalPrice, order.GetTotalPrice());
        }
    }
}
