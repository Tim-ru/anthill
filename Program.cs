using System;

namespace Example5
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Anthill();

            while(true)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false);
                    if (key.Key == ConsoleKey.Spacebar)
                        a.AddFood();
                    if (key.Key == ConsoleKey.A)
                        a.AddAnt();
                    if (key.Key == ConsoleKey.Q)
                        a.AddQueen();
                }

                a.Update();
                a.Draw();
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
