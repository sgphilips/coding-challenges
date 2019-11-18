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
        public void IsInvalidPosition(int x, int y)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Position(x, y));
            Assert.Equal("Coordinates must be positive numbers", exception.Message);
        }

        [Fact]
        public void IsEqualPosition()
        {
            var position1 = new Position(0,0);
            var position2 = new Position(0,0);

            Assert.True(position1.Equals(position2));
            Assert.True(position2.Equals(position1));
        }

        [Fact]
        public void IsNotEqualPosition()
        {
            var position1 = new Position(1, 2);
            var position2 = new Position(2, 1);

            Assert.False(position1.Equals(position2));
            Assert.False(position2.Equals(position1));
        }

        [Fact]
        public void IsNotEqualObjectType()
        {
            var position = new Position(1, 1);
            var battleArena = new BattleArena(1,1);

            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.False(position.Equals(battleArena));
        }

        [Fact]
        public void IsValidStringRepresentation()
        {
            var position = new Position(0,0);
            var coordinates = position.ToString();
            Assert.True(coordinates == "(0,0)");
        }

        [Fact]
        public void IsClone()
        {
            var position = new Position(0,0);
            var clonePosition = position.Clone();
            // ReSharper disable once PossibleUnintendedReferenceComparison
            Assert.True(position != clonePosition);
        }
    }
}
