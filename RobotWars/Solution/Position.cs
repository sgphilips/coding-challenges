using System;

namespace Solution
{
    public struct Position
    {
        internal int X { get; set; }
        internal int Y { get; set; }

        public Position(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Coordinates must be positive numbers");
            }

            X = x;
            Y = y;
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override string ToString()
        {
            return $"({X.ToString()},{Y.ToString()})";
        }
    }
}
