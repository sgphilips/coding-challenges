using System;
using Solution;
using Xunit;

namespace Tests
{
    public class BattleArenaTests
    {
        [Theory]
        [InlineData(-5, 5)]
        [InlineData(7, -5)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        public void ShouldThrowArgumentExceptionWhenCreatingInvalidBattleArena(int x, int y)
        {
            var exception = Assert.Throws<ArgumentException>(() => new BattleArena(x, y));
            Assert.Equal("Coordinates must be positive numbers and different than (0,0)", exception.Message);
        }

        [Theory]
        [InlineData(5, 6)]
        [InlineData(6, 5)]
        public void ShouldReturnFalseWhenPositionOutsideTheBattleArena(int x, int y)
        {
            var battleArena = new BattleArena(5,5);
            var position = new Position(x, y);

            Assert.False(battleArena.IsPositionInsideBattleArena(position));
        }

        [Fact]
        public void ShouldContainRobotWhenRobotAddedToTheListOfRobotsOfTheBattleArena()
        {
            var startingPosition = new Position(1, 2);
            var battleArena = new BattleArena(5, 5);
            var robot = new Robot(startingPosition, Direction.East, battleArena);

            Assert.True(battleArena.Robots.Count == 1);
            Assert.Contains(robot, battleArena.Robots);
        }

        [Fact]
        public void ShouldReturnTrueWhenBattleArenaFull()
        {
            var battleArena = new BattleArena(0, 1);
            // ReSharper disable once UnusedVariable
            var robot1 = new Robot(new Position(0, 0), Direction.West, battleArena);
            // ReSharper disable once UnusedVariable
            var robot2 = new Robot(new Position(0, 1), Direction.West, battleArena);

            Assert.True(battleArena.IsFull());
        }
    }
}
