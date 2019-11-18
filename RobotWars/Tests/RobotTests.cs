using System;
using Solution;
using Xunit;

namespace Tests
{
    public class RobotTests
    {
        public static TheoryData<Robot, Direction> RotateLeftData =>
            new TheoryData<Robot, Direction>
            {
                { new Robot(new Position(0, 0), Direction.North, new BattleArena(10, 10)), Direction.West },
                { new Robot(new Position(4, 5), Direction.West, new BattleArena(10, 10)), Direction.South },
                { new Robot(new Position(5, 4), Direction.South, new BattleArena(10, 10)), Direction.East },
                { new Robot(new Position(7, 7), Direction.East, new BattleArena(10, 10)), Direction.North }
            };

        public static TheoryData<Robot, Direction> RotateRightData =>
            new TheoryData<Robot, Direction>
            {
                { new Robot(new Position(0, 0), Direction.North, new BattleArena(10, 10)), Direction.East },
                { new Robot(new Position(4, 5), Direction.West, new BattleArena(10, 10)), Direction.North },
                { new Robot(new Position(5, 4), Direction.South, new BattleArena(10, 10)), Direction.West },
                { new Robot(new Position(7, 7), Direction.East, new BattleArena(10, 10)), Direction.South }
            };

        public static TheoryData<Robot, Position> MoveData =>
            new TheoryData<Robot, Position>
            {
                {new Robot(new Position(0, 0), Direction.North, new BattleArena(10, 10)), new Position(0, 1) },
                {new Robot(new Position(4, 5), Direction.West, new BattleArena(10, 10)), new Position(3, 5) },
                {new Robot(new Position(5, 4), Direction.South, new BattleArena(10, 10)), new Position(5, 3) },
                {new Robot(new Position(7, 7), Direction.East, new BattleArena(10, 10)), new Position(8, 7) }
            };

        public static TheoryData<Robot> InvalidMoveData =>
            new TheoryData<Robot>
            {
                {new Robot(new Position(0, 0), Direction.West, new BattleArena(9, 9)) },
                {new Robot(new Position(0, 0), Direction.South, new BattleArena(9, 9)) },
                {new Robot(new Position(9, 9), Direction.North, new BattleArena(9, 9)) },
                {new Robot(new Position(9, 9), Direction.East, new BattleArena(9, 9)) },
                {new Robot(new Position(9, 0), Direction.South, new BattleArena(9, 9)) },
                {new Robot(new Position(9, 0), Direction.East, new BattleArena(9, 9)) },
                {new Robot(new Position(0, 9), Direction.North, new BattleArena(9, 9)) },
                {new Robot(new Position(0, 9), Direction.West, new BattleArena(9, 9)) }
            };

        [Fact]
        public void IsInvalidDirection()
        {
            var battleArena = new BattleArena(5, 5);
            var exception = Assert.Throws<ArgumentException>(() => new Robot(new Position(0, 0), Enum.Parse<Direction>("8"), battleArena));
            Assert.Equal("Invalid direction. Can't create the robot.", exception.Message);
        }

        [Fact]
        public void IsStartingPositionOutsideTheBattleArena()
        {
            var battleArena = new BattleArena(5, 5);
            var exception = Assert.Throws<ArgumentException>(() => new Robot(new Position(5, 6), Direction.East, battleArena));
            Assert.Equal("Invalid starting position. Robot can't start outside the battle arena.", exception.Message);
        }

        [Fact]
        public void IsStartingPositionTheSameAsOtherRobot()
        {
            var battleArena = new BattleArena(5, 5);
            var startingPosition = new Position(1,2);
            var robot = new Robot(startingPosition, Direction.East, battleArena);
            robot.Move();
            var exception = Assert.Throws<ArgumentException>(() => new Robot(new Position(2, 2), Direction.East, battleArena));
            Assert.Equal("Invalid starting position. Robot can't be in the same place as another robot.", exception.Message);
        }

        [Theory]
        [MemberData(nameof(RotateLeftData))]
        public void IsRotatingLeft(Robot robot, Direction expectedDirection)
        {
            robot.RotateLeft();
            Assert.True(robot.Direction == expectedDirection);
        }

        [Theory]
        [MemberData(nameof(RotateRightData))]
        public void IsRotatingRight(Robot robot, Direction expectedDirection)
        {
            robot.RotateRight();
            Assert.True(robot.Direction == expectedDirection);
        }

        [Theory]
        [MemberData(nameof(MoveData))]
        public void IsMoving(Robot robot, Position expectedPosition)
        {
            robot.Move();
            Assert.True(robot.Position.Equals(expectedPosition));
        }

        [Fact]
        public void IsInvalidMoveBecauseOtherRobot()
        {
            var battleArena = new BattleArena(5, 5);

            var startingPositionRobot1 = new Position(1, 2);
            var robot1 = new Robot(startingPositionRobot1, Direction.East, battleArena);

            var startingPositionRobot2 = new Position(2, 2);
            // ReSharper disable once UnusedVariable
            var robot2 = new Robot(startingPositionRobot2, Direction.East, battleArena);

            var exception = Assert.Throws<InvalidMoveException>(() => robot1.Move());
            Assert.Equal($"Robot {robot1.Id} can't move into space ({startingPositionRobot2}) because it's occupied by another robot.", exception.Message);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveData))]
        public void IsInvalidMoveBecauseOfBattleArena(Robot robot)
        {
            var exception = Assert.Throws<InvalidMoveException>(() => robot.Move());
            Assert.Equal($"Robot {robot.Id} can't move outside the battle arena.", exception.Message);
        }

        [Fact]
        public void IsInvalidToAddRobotToTheBattleArena()
        {
            var battleArena = new BattleArena(1, 0);

            var startingPositionRobot1 = new Position(0, 0);
            // ReSharper disable once UnusedVariable
            var robot1 = new Robot(startingPositionRobot1, Direction.East, battleArena);

            var startingPositionRobot2 = new Position(1, 0);
            // ReSharper disable once UnusedVariable
            var robot2 = new Robot(startingPositionRobot2, Direction.East, battleArena);

            var exception = Assert.Throws<ArgumentException>(() => new Robot(startingPositionRobot1, Direction.East, battleArena));
            Assert.Equal("Can't add the robot because the battle arena is full.", exception.Message);
        }

        [Fact]
        public void IsPositionTheSameAfterInvalidMove()
        {
            var battleArena = new BattleArena(5, 5);

            var startingPositionRobot1 = new Position(1, 2);
            var robot1 = new Robot(startingPositionRobot1, Direction.East, battleArena);

            var startingPositionRobot2 = new Position(2, 2);
            // ReSharper disable once UnusedVariable
            var robot2 = new Robot(startingPositionRobot2, Direction.East, battleArena);

            Assert.Throws<InvalidMoveException>(() => robot1.Move());

            var expectedPosition = new Position(1, 2);
            Assert.True(robot1.Position.Equals(expectedPosition));
        }
    }
}
