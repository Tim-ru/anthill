using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Fish : Movier
    {
        const int SPAWN_HP = 15;

        public override (double dx, double dy) GetNextMove(IEnumerable<Movier> objects)
        {
            var target = Nearest(objects, item => item is Food && !item.ground);
            return ShiftTo(target, speed);
        }
        public override void Move(double dx, double dy, Collision c)
        {
            x += dx;
            y += dy;
            if (this.hp >= SPAWN_HP && OnSpawn != null)
                OnSpawn(this);
        }
        public override void Touch(Movier other)
        {            
            if (other is Food && !other.ground)
                DoDamage(other);
        }
        public override void Draw()
        {
            ConsoleEx.Print((int)x, (int)y, "#", ConsoleColor.White);
        }

        public override Movier MakeChild()
        {
            this.hp /= 2;

            var child = new Fish() {
                x = this.x,
                y = this.y,
                size = this.size,
                speed = this.speed * 0.7,
                damage = this.damage,
                hp = this.hp,
                ground = this.ground
            };

            return child;
        }

    }
}