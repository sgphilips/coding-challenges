using System;
using Supermarket;
using Xunit;

namespace Tests
{
    public class DiscountTests
    {
        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void ShouldThrowArgumentExceptionWhenCreatingItemWithNegativeOrZeroDiscountPrice(int discountPrice)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Item("X", 100, 10, discountPrice));
            Assert.Equal("Discount price must be greater than zero", exception.Message);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void ShouldThrowArgumentExceptionWhenCreatingItemWithNegativeOrZeroDiscountQuantity(int discountQuantity)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Item("X", 100, discountQuantity, 100));
            Assert.Equal("Discount quantity must be greater than zero", exception.Message);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void ShouldThrowArgumentExceptionWhenUpdatingDiscountWithNegativeOrZeroDiscountQuantity(int discountQuantity)
        {
            var item = new Item("X", 100, 10, 10);
            var exception = Assert.Throws<ArgumentException>(() => item.UpdateDiscount(discountQuantity, 100));
            Assert.Equal("Discount quantity must be greater than zero", exception.Message);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void ShouldThrowArgumentExceptionWhenUpdatingDiscountWithNegativeOrZeroDiscountPrice(int discountPrice)
        {
            var item = new Item("X", 100, 10, 10);
            var exception = Assert.Throws<ArgumentException>(() => item.UpdateDiscount(100, discountPrice));
            Assert.Equal("Discount price must be greater than zero", exception.Message);
        }
    }
}
