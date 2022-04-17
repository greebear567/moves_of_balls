using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moves_of_balls
{
    class Vector
    {
        public Point p1;
        public Point p2;
        public double x;
        public double y;
        public double length;

        public Vector(Point start_pos)
        {
            p1 = start_pos;
            Random some = new Random();
            p2 = new Point(some.Next(-5000, 5000), some.Next(-500, 500));
            x = p2.X - p1.X;
            y = p2.Y - p1.Y;
            length = Math.Sqrt(x*x + y*y);
        }
    }
}
