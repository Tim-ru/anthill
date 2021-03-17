using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Food : Movier
    {
        public override (double dx, double dy) GetNextMove(IEnumerable<Movier> objects)
        {
            if (ground)
                return (0,0);
            return (0,speed);
        }
        public override void Move(double dx, double dy, Collision c)
        {
            if (c == Collision.Horizontal)
                ground = true;
            x += dx;
            y += dy;
        }
        public override void Draw()
        {
            ConsoleEx.Print((int)x, (int)y, ".");
        }
    }
}