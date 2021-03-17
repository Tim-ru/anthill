using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    class Aquarium
    {
        const int LEFT = 0;
        const int RIGHT = 79;
        const int TOP = 0;
        const int BOTTOM = 24;

        List<Movier> objects = new List<Movier>();

        Random rnd = new Random();

        public void AddFood()
        {
            objects.Add(
                new Food()
                {
                    x = rnd.Next(LEFT, RIGHT),
                    y = TOP,
                    size = 0.5,
                    speed = 0.5,
                    hp = 5,
                    ground = false
                }
            );
        }

        public void AddSnail()
        {
            objects.Add(
                new Snail()
                {
                    x = rnd.Next(LEFT, RIGHT),
                    y = BOTTOM,
                    size = 1,
                    speed = 0.3,
                    damage = 2,
                    hp = 10,
                    ground = true
                }
            );
        }

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