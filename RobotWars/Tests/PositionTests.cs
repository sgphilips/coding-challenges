using System;
using Solution;
using Xunit;

namespace Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData(-5, 5)]
        [InlineData(7, -5)]
        [InlineData(-1, -1)]
        public void ShouldThrowArgumentExceptionWhenCreatingInvalidPosition(int x, int y)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Position(x, y));
            Assert.Equal("Coordinates must be positive numbers", exception.Message);
        }

        [Fact]
        public void ShouldReturnEqualWhenComparingEqualPositions()
        {
            var position1 = new Position(0,0);
            var position2 = new Position(0,0);

            Assert.Equal(position1,position2);
            Assert.Equal(position2,position1);
        }

        [Fact]
        public void ShouldReturnNotEqualWhenComparingDifferentPositions()
        {
            var position1 = new Position(1, 2);
            var position2 = new Position(2, 1);

            Assert.NotEqual(position1, position2);
            Assert.NotEqual(position2, position1);
        }

        [Fact]
        public void ShouldReturnValidStringRepresentation()
        {
            var position = new Position(0,0);
            var coordinates = position.ToString();
            Assert.True(coordinates == "(0,0)");
        }

        [Fact]
        public void ShouldReturnEqualWhenCloningPosition()
        {
            var position = new Position(0,0);
            var clonePosition = position.Clone();

            Assert.Equal(position, clonePosition);
        }
    }
}
