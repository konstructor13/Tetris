using System;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Draw(2, 3, '#');

            Console.ReadKey();
        }

        static void Draw(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}