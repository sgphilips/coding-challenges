using System;
using Supermarket;
using Xunit;

namespace Tests
{
    public class ItemTests
    {
        [Fact]
        public void ShouldThrowArgumentExceptionWhenCreatingItemWithNegativeUnitPrice()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Item("X", -100));
            Assert.Equal("Can't create a item with a negative unit price", exception.Message);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionWhenCreatingItemWithDiscountAndNegativeUnitPrice()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Item("X", -100,10,10));
            Assert.Equal("Can't create a item with a negative unit price", exception.Message);
        }

        [Fact]
        public void ShouldUpdateUnitPrice()
        {
            var item = new Item("X", 100);
            item.UpdateUnitPrice(200);

            Assert.Equal(200, item.UnitPrice);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionWhenUpdatingUnitPriceWithNegativeUnitPrice()
        {
            var item = new Item("X", 100);
            var exception = Assert.Throws<ArgumentException>(() => item.UpdateUnitPrice(-100));
            Assert.Equal("Can't update the item with a negative unit price", exception.Message);
        }

        [Fact]
        public void ShouldUpdateDiscount()
        {
            var item = new Item("X", 10,10,10);
            item.UpdateDiscount(100, 200);

            Assert.Equal(100, item.Discount.Quantity);
            Assert.Equal(800, item.Discount.Amount);
        }
    }
}
