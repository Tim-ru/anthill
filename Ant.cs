using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Example5
{
    class Ant : Movier
    {
        const int SPAWN_HP = 30;

        public override (double dx, double dy) GetNextMove(IEnumerable<Movier> objects)
        {
            var target = Nearest(objects, item => item is Food);
            
            if (busy == true) 
                target = Nearest(objects, item => item is Queen);
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
            if (other is Food) {
                DoDamage(other);
                busy = true;
            }

            if (other is Queen) {
                busy = false;
            }
                
            // else if (other is Queen && this.hp > 10)
            //     other.DoDamage(this);
            // else if (other is Beetle)
            //     DoDamage(other);
        }
    

        public override void Draw()
        {
            
            if (this.busy == true)
            {
                ConsoleEx.Print((int)x, (int)y, "ant", ConsoleColor.Red);
                return;
            }
            ConsoleEx.Print((int)x, (int)y, "ant", ConsoleColor.Yellow);
        }

        public override Movier MakeChild()
        {
            this.hp /= 2;

            var child = new Ant() {
                x = this.x,
                y = this.y,
                size = this.size,
                speed = this.speed * 0.7,
                damage = this.damage,
                hp = this.hp,
                ground = this.ground,
                busy = this.busy
            };

            return child;
        }

    }
}