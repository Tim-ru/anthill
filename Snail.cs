using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Snail : Movier
    {
        public override (double dx, double dy) GetNextMove(IEnumerable<Movier> objects)
        {
            var target = Nearest(objects, item => item is Food && item.ground);
            return ShiftTo(target, speed);
        }
        public override void Move(double dx, double dy, Collision c)
        {
            x += dx;
            y += dy;
        }
        public override void Touch(Movier other)
        {            
            if (other is Food && other.ground)
                DoDamage(other);
        }
        public override void Draw()
        {
            ConsoleEx.Print((int)x, (int)y, "@", ConsoleColor.Yellow);
        }
    }
}