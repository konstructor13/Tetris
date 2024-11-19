using System;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Figure[] figures = new Figure[2];
            figures[0] = new Square(2, 5, '#');
            figures[1] = new Stick(6, 6, '#');

            foreach (Figure f in figures)
            {
                f.Draw();
            }

            Console.ReadKey();
        }
    }
}