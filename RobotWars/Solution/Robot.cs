using System;

namespace Solution
{
    public class Robot
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        private BattleArena BattleArena { get; set; }

        public Robot(Position position, Direction direction, BattleArena battleArena)
        {
            IsRobotValid(position, direction, battleArena);

            Id = battleArena.Robots.Count;
            Position = position;
            Direction = direction;
            BattleArena = battleArena;

            battleArena.Robots.Add(this);
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void IsRobotValid(Position position, Direction direction, BattleArena battleArena)
        {
            if (!Enum.IsDefined(typeof(Direction), direction))
            {
                throw new ArgumentException("Invalid direction. Can't create the robot.");
            }

            if (battleArena.IsFull())
            {
                throw new ArgumentException("Can't add the robot because the battle arena is full.");
            }

            if (!battleArena.IsPositionInsideBattleArena(position))
            {
                throw new ArgumentException("Invalid starting position. Robot can't start outside the battle arena.");
            }

            if (!battleArena.IsPositionUnoccupied(battleArena.Robots.Count, position))
            {
                throw new ArgumentException("Invalid starting position. Robot can't be in the same place as another robot.");
            }
        }

        public void RotateLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void RotateRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Move()
        {
            var newPosition = Position.Clone();

            switch (Direction)
            {
                case Direction.North:
                    newPosition.Y++;
                    break;
                case Direction.East:
                    newPosition.X++;
                    break;
                case Direction.South:
                    newPosition.Y--;
                    break;
                case Direction.West:
                    newPosition.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            CheckPosition(newPosition);
            Position = newPosition;
        }

        private void CheckPosition(Position newPosition)
        {
            if (!BattleArena.IsPositionInsideBattleArena(newPosition))
            {
                throw new InvalidMoveException($"Robot {Id} can't move outside the battle arena.");
            }

            if (!BattleArena.IsPositionUnoccupied(Id, newPosition))
            {
                throw new InvalidMoveException($"Robot {Id} can't move into space ({newPosition}) because it's occupied by another robot.");
            }
        }
    }
}
