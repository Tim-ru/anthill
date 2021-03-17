using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Aquarium
    {
        const double LEFT = 0;
        const double RIGHT = 79;
        const double TOP = 0;
        const double BOTTOM = 24;

        List<Movier> objects = new List<Movier>();

        public void Update()
        {
            //движение
            foreach(var obj in objects)
            {
                (double dx, double dy) = obj.GetNextMove(objects);
                Collision c = Collision.None;
                if (obj.x + dx < LEFT || obj.x+dx > RIGHT) { dx = 0; c = Collision.Vertical; }
                if (obj.y + dy < TOP || obj.y+dy > BOTTOM) { dy = 0; c = Collision.Horizontal; }
                obj.Move(dx, dy, c);
            }

            //касания
            foreach(var obj1 in objects)
                foreach(var obj2 in objects)
                    if (obj1 != obj2 && obj1.Dist(obj2) < obj1.size + obj2.size)
                        obj1.Touch(obj2);

            //удаление
            for (int i=objects.Count - 1; i>=0; i--)
                if (objects[i].hp <= 0)
                    objects.RemoveAt(i);
        }
        
        public void Draw()
        {
            Console.Clear();
            objects.ForEach(item => item.Draw());
        }
    }
}