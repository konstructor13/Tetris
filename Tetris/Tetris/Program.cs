using System;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Figure stick = new Stick(20, 5, '#');

            stick.Draw();
            Thread.Sleep(500);

            stick.Clear();
            stick.Rotate();
            stick.Draw();

            Console.ReadKey();
        }
    }
}