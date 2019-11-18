using System;

namespace Solution
{
    public class Position
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

        public override bool Equals(object obj)
        {
            if (obj is Position position)
            {
                return Equals(position);
            }

            return false;
        }

        protected bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
