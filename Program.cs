using System;

namespace Example5
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Aquarium();

            while(true)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false);
                    if (key.Key == ConsoleKey.Spacebar)
                        a.AddFood();
                    if (key.Key == ConsoleKey.S)
                        a.AddSnail();
                    if (key.Key == ConsoleKey.F)
                        a.AddFish();
                }

                a.Update();
                a.Draw();
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
