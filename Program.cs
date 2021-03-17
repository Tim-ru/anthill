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
                a.Update();
                a.Draw();
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
