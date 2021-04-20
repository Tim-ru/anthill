using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Queen : Movier
    {
        const int SPAWN_HP = 60;
        
        // public override void Touch(Movier other)
        // {            
        //     if (other is Ant && Ant.busy == true)
        //         DoDamage(other);
        //         // AddAnt()
        // }
        public override void Draw()
        {
            ConsoleEx.Print((int)x, (int)y, "Q", ConsoleColor.White);
        }

        public override Movier MakeChild()
        {
            this.hp -= 5;

            var child = new Queen() {
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