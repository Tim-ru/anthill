using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Movier
    {
        public double x,y,size;
        public double speed;
        public int damage;
        public int hp;
        public bool ground;

        public virtual (double dx, double dy) GetNextMove(IEnumerable<Movier> objects) { return (0,0); }
        public virtual void Move(double dx, double dy, Collision c) { }
        public virtual void Touch(Movier other) { }
        public virtual void Draw() { }

        public void DoDamage(Movier target)
        {
            var dmg = Math.Min(this.damage, target.hp);
            this.hp += dmg;
            target.hp -= dmg;
        }
        public double Dist(Movier other)
        {
            if (other == null)
                return double.MaxValue;
            var cx = this.x - other.x;
            var cy = this.y - other.y;
            return Math.Sqrt(cx*cx + cy*cy);
        }
        protected Movier Nearest (IEnumerable<Movier> objects, Func<Movier, bool> condition)
        {
            return objects.Where(condition).OrderBy(Dist).FirstOrDefault();
        }
        protected (double dx, double dy) ShiftTo(Movier other, double shift)
        {
            if (other == null)
                return (0,0);

            var dist = Dist(other);
            if (dist < 0.00001)
                return (0,0);

            var cx = other.x - this.x;
            var cy = other.y - this.y;

            shift = Math.Min(dist, shift);

            var dx = shift*cx/dist;
            var dy = shift*cy/dist;

            return (dx,dy);
        }
    }
}