using System;

namespace Example5
{
    class ConsoleEx
    {
        public static void Print(int x, int y, string str, ConsoleColor c = ConsoleColor.White)
        {
            Console.ForegroundColor = c;
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(str);
        }
    }
}