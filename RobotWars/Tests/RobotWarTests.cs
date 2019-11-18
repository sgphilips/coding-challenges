using Solution;
using Xunit;

namespace Tests
{
    public class RobotWarTests
    {
        [Fact]
        public void RobotWarExample()
        {
            var battleArena = new BattleArena(5, 5);
            var robot1 = new Robot(new Position(1, 2), Direction.North, battleArena);
            var robot2 = new Robot(new Position(3,3), Direction.East, battleArena);

            robot1.RotateLeft();
            robot1.Move();
            robot1.RotateLeft();
            robot1.Move();
            robot1.RotateLeft();
            robot1.Move();
            robot1.RotateLeft();
            robot1.Move();
            robot1.Move();

            robot2.Move();
            robot2.Move();
            robot2.RotateRight();
            robot2.Move();
            robot2.Move();
            robot2.RotateRight();
            robot2.Move();
            robot2.RotateRight();
            robot2.RotateRight();
            robot2.Move();

            var expectedPosition1 = new Position(1, 3);

            Assert.True(robot1.Direction == Direction.North);
            Assert.True(robot1.Position.Equals(expectedPosition1));

            var expectedPosition2 = new Position(5, 1);

            Assert.True(robot2.Direction == Direction.East);
            Assert.True(robot2.Position.Equals(expectedPosition2));
        }
    }
}
