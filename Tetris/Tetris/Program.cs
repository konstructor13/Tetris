using System;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(PlayGround.WIDTH, PlayGround.HEIGHT);
            Console.SetBufferSize(PlayGround.WIDTH, PlayGround.HEIGHT);

            FigureGenerator generator = new FigureGenerator(20, 0, '#'); 
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    HandleKey(currentFigure, key);
                }
            }

            Console.ReadKey();
        }

        private static void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    currentFigure.TryRotate();
                    break;
            }
        }
    }
}