using System;
using System.Collections.Generic;
using System.Text;

namespace Day15
{
    public class Position
    {
        public double X, Y;
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
        public string AsText()
        {
            return $"({X}, {Y})";
        }
        public double DistanceFrom(Position pos)
        {
            return Math.Sqrt(Math.Pow((pos.X - X), 2) + Math.Pow((pos.Y - Y), 2));
        }
    }
}
