using System;
using System.Collections.Generic;

namespace Solution
{
    public class BattleArena
    {
        internal int Width { get; }
        internal int Height { get; }
        public List<Robot> Robots { get; }

        public BattleArena(int x, int y)
        {
            // ReSharper disable once ArrangeRedundantParentheses
            var isStartingPosition = (x == 0 && y == 0);
            if (x < 0 || y < 0 || isStartingPosition)
            {
                throw new ArgumentException("Coordinates must be positive numbers and different than (0,0)");
            }

            Width = x + 1;
            Height = y + 1;

            Robots = new List<Robot>();
        }

        public bool IsPositionInsideBattleArena(Position position)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < Width && position.Y < Height;
        }

        public bool IsPositionUnoccupied(int id, Position position)
        {
            foreach (var robot in Robots)
            {
                if (robot.Position.Equals(position) && robot.Id != id)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFull()
        {
            // ReSharper disable once ArrangeRedundantParentheses
            return Robots.Count == (Width * Height);
        }
    }
}
