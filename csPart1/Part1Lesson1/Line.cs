using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    class Line
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Line(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public double Length()
        {
            return Math.Sqrt( Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }

        public void Print() {
            Console.WriteLine($"Длина линии с координатами A({A.X},{A.Y}), B({B.X},{B.Y}) : {Length():#.##}");
        }
    }
}
